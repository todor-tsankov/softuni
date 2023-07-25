using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Songs
{
    class Songs
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<song> songs = new List<song>();

            for (int i = 0; i < n; i++)
            {
                songs.Add(new song(Console.ReadLine()));
            }

            string type = Console.ReadLine();

            foreach (var item in songs)
            {
                if (item.TypeList == type || type == "all")
                {
                    Console.WriteLine(item.Name);
                }
            }
        }
    }

    class song
    {
        public song(string input)
        {
            string[] parts = input.Split('_');
            TypeList = parts[0];
            Name = parts[1];
            Time = parts[2];
        }
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }

    }
}
