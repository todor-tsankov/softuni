using System;
using System.Collections.Generic;
using System.Text;

namespace P01ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double GetSurfaceArea()
        {
            return this.GetLateralSurfaceArea() + this.Width * this.Length * 2;
        }

        public double GetLateralSurfaceArea()
        {
            return ((this.Length * this.Height) + (this.Width * this.Height)) * 2;
        }

        public double GetValume()
        {
            return this.Length * this.Width * this.Height;
        }

        private double Length
        {
            get
            {
                return this.length;
            }
            set 
            {
                ValidateParameter(value, nameof(this.Length));

                this.length = value;
            }
        }

        private double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                ValidateParameter(value, nameof(this.Width));

                this.width = value;
            }
        }

        private double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                ValidateParameter(value, nameof(this.Height));

                this.height = value;
            }
        }

        private void ValidateParameter(double par, string propertyName)
        {
            if (par <= 0)
            {
                throw new ArgumentException($"{propertyName} cannot be zero or negative.");
            }
        }
    }
}
