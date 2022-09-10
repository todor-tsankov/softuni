using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawData
{
    class Engine
    {
        public Engine(string engineSpeed, string enginePower)
        {
            EnginePower =int.Parse(enginePower);
            EngineSpeed = int.Parse(engineSpeed);
        }
        public int EnginePower { get; set; }
        public int EngineSpeed { get; set; }
    }
}
