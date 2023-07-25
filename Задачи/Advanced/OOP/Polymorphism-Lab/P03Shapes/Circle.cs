using System;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        private const int RADIUS_MIN_VALUE = 0;

        private int radius;
        public Circle(int radius)
        {
            if (radius <= RADIUS_MIN_VALUE)
            {
                throw new ArgumentException();
            }

            this.radius = radius;
        }
        public override double CalculateArea()
        {
            return Math.PI * this.radius * this.radius;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * this.radius;
        }

        public override string Draw()
        {
            var sb = new StringBuilder();

            double rIn = this.radius - 0.4;
            double rOut = this.radius + 0.4;

            for (int y = this.radius; y >= -this.radius; y--)
            {
                for (int x = -this.radius; x < rOut; x++)
                {
                    double value = x * x + y * y;

                    if (value >= rIn * rIn && value <= rOut * rOut)
                    {
                        sb.Append("*");
                    }
                    else
                    {
                        sb.Append(" ");
                    }

                }

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
