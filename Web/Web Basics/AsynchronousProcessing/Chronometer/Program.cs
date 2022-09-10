using Chronometer.Core;
using System;

namespace Chronometer
{
    public class Program
    {
        public static void Main()
        {
            var chronometer = new Chronometer.Models.Chronometer();
            var engine = new ChronometerEngine(chronometer);

            engine.Run();
        }
    }
}
