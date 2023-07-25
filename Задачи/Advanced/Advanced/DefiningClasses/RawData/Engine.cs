using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Engine
    {
        public Engine(double speed, double power)
        {
            this.Speed = speed;
            this.Power = power;
        }
        public double Speed { get; set; }
        public double Power { get; set; }
    }
}
