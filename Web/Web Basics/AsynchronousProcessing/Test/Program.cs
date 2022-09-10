using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RouteDateCollector
{
    public class Program
    {
        public static async Task Main()
        {
            var dataCollector = new DataCollector();

            await dataCollector.RunAsync();
        }
    }
}

