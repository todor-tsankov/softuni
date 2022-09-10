using System.Diagnostics;
using System.Collections.Generic;
using Chronometer.Models.Contracts;

namespace Chronometer.Models
{
    public class Chronometer : IChronometer
    {
        private readonly List<string> laps;
        private readonly Stopwatch stopwatch;

        public Chronometer()
        {
            this.laps = new List<string>();
            this.stopwatch = new Stopwatch();
        }

        public string Time => this.GetTime();

        public List<string> Laps => this.laps;

        public void Start()
        {
            this.stopwatch.Start();
        }

        public void Stop()
        {
            this.stopwatch.Stop();
        }

        public void Reset()
        {
            this.laps.Clear();
            this.stopwatch.Reset();
        }

        public string Lap()
        {
            this.laps.Add(this.Time);

            return this.Time;
        }

        private string GetTime()
        {
            var timeSpan = this.stopwatch.Elapsed;

            var minutes = ((int)timeSpan.TotalMinutes).ToString("D2");
            var seconds = ((int)timeSpan.TotalSeconds).ToString("D2");
            var milliseconds = ((int)timeSpan.TotalMilliseconds).ToString("D4");

            return $"{ minutes}:{ seconds}:{ milliseconds}";
        }
    }
}
