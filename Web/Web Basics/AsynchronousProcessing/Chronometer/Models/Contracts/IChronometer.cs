using System.Collections.Generic;

namespace Chronometer.Models.Contracts
{
    public interface IChronometer
    {
        string Time { get; }

        List<string> Laps { get; }

        void Start();

        void Stop();

        string Lap();

        void Reset();
    }
}
