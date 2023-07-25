using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : ICar, IElectricCar
    {
        private string model;
        private string color;
        private int battery;

        public Tesla(string model, string color, int battery)
        {
            this.Model = model;
            this.Color = color;
            this.Battery = battery;
        }
        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException();
                }

                this.model = value;
            }
        }

        public string Color
        {
            get
            {
                return this.color;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException();
                }

                this.color = value;
            }
        }
        public int Battery
        {
            get
            {
                return this.battery;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }

                this.battery = value;
            }
        }

        public string Start()
        {
            return "Breaaak!";
        }

        public string Stop()
        {
            return "Stopped";
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.Color} Tesla {this.Model} with {this.Battery} Batteries");
            sb.AppendLine("Engine start");
            sb.AppendLine(this.Start());

            return sb.ToString()
                     .TrimEnd();
        }
    }
}
