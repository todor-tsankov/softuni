using System;
using System.Linq;
using Chronometer.Core.Contracts;
using Chronometer.Models.Contracts;

namespace Chronometer.Core
{
    public class ChronometerEngine : IEngine
    {
        private readonly IChronometer chronometer;

        public ChronometerEngine(IChronometer chronometer)
        {
            this.chronometer = chronometer;
        }

        public void Run()
        {
            while (true)
            {
                var command = Console.ReadLine();

                if (command == "exit")
                {
                    break;
                }

                var output = this.ProcessCommand(command);

                if (output != string.Empty)
                {
                    Console.WriteLine(output);
                }
            }
        }

        private string ProcessCommand(string command)
        {
            var output = string.Empty;

            if (command == "start")
            {
                this.chronometer.Start();
            }
            else if (command == "stop")
            {
                this.chronometer.Stop();
            }
            else if (command == "lap")
            {
                output = this.chronometer.Lap();

            }
            else if (command == "laps")
            {
                var laps = this.chronometer.Laps;

                if (laps.Any())
                {
                    output += "Laps:";
                    for (int i = 0; i < laps.Count; i++)
                    {
                        output += $"{i}. {laps[i]}\n";
                    }
                }
                else
                {
                    output = "Laps: no laps";
                }
            }
            else if (command == "time")
            {
                output = this.chronometer.Time;
            }
            else if (command == "reset")
            {
                this.chronometer.Reset();
            }

            return output;
        }
    }
}
