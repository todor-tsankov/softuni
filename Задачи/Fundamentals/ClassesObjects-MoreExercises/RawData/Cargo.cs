using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawData
{
    class Cargo
    {
        public Cargo(string cargoWeight, string cargoType)
        {
            CargoWeight = int.Parse(cargoWeight);
            CargoType = cargoType;
        }
        public int CargoWeight { get; set; }
        public string CargoType { get; set; }
    }
}
