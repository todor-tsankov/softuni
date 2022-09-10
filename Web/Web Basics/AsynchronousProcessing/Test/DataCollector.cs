using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Globalization;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using Newtonsoft.Json;

namespace RouteDateCollector
{
    public class DataCollector
    {
        private const int MinRouteIndex = 0;
        private const int MaxRouteIndex = 120_000;

        private const string regexFormat = @"\d{2}\.\d{2}\.\d{4}";
        private const string UrlFormat = @"http://db-sandsteinklettern.gipfelbuch.de/komment.php?wegid={0}";

        private HttpClient client = new HttpClient();

        private Regex dateRegex = new Regex(regexFormat);
        private DateTime minValidDate = new DateTime(1700, 1, 1);

        public async Task RunAsync()
        {
            var dates = await GetRouteDatesAsync();
            var orderedDates = GroupDatesByYear(dates);

            var jsonStr = JsonConvert.SerializeObject(orderedDates, Formatting.Indented);

            File.WriteAllText("Routes.json", jsonStr);
        }


        private async Task<List<DateTime>> GetRouteDatesAsync()
        {
            var dates = new List<DateTime>();

            for (int i = MinRouteIndex; i < MaxRouteIndex; i++)
            {
                var url = string.Format(UrlFormat, i);

                var htmtStr = await client.GetStringAsync(url);
                var match = this.dateRegex.Match(htmtStr);

                if (match.Success)
                {
                    var valid = DateTime.TryParseExact(match.Value, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date);

                    if (valid && date > this.minValidDate)
                    {
                        dates.Add(date);

                        Console.WriteLine($"Successfully added date of route with id: {i}");
                    }
                }
            }

            return dates;
        }
        private List<YearInfo> GroupDatesByYear(List<DateTime> dates)
        {
            var orderedDates = dates
                .GroupBy(x => x.Year)
                .OrderByDescending(x => x.Key)
                .Select(x => new YearInfo
                {
                    Year = x.Key,
                    RoutesCount = x.Count()
                })
                .ToList();

            return orderedDates;
        }
    }
}
