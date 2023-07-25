using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Cargo
    {
        public Cargo(double weight, string type)
        {
            this.Weight = weight;
            this.Type = type;
        }
        public double Weight { get; set; }
        public string Type { get; set; }
    }
}
