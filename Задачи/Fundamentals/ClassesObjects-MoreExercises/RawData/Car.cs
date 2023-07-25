using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawData
{
    class Car
    {
        public Car(string[] carInformation)
        {
            Model = carInformation[0];
            Engine = new Engine(carInformation[1], carInformation[2]);
            Cargo = new Cargo(carInformation[3], carInformation[4]);
        }
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
    }
}
