using System;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private const double HEIGHT_MIN_VALUE = 0;
        private const double WIDTH_MIN_VALUE = 0;

        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            if (height <= HEIGHT_MIN_VALUE && width <= WIDTH_MIN_VALUE)
            {
                throw new ArgumentException();
            }

            this.height = height;
            this.width = width;
        }
        public override double CalculateArea()
        {
            return this.height * this.width;
        }

        public override double CalculatePerimeter()
        {
            return 2 *(this.height + this.width);
        }

        public override string Draw()
        {
            var sb = new StringBuilder();

            for (int row = 0; row < this.height; row++)
            {
                if (row == 0 || row == this.height - 1)
                {
                    var line = new String('*', (int) this.width);

                    sb.AppendLine(line);
                }
                else
                {
                    DrawLine(sb);
                }
            }

            return sb.ToString()
                     .Trim();
        }

        private void DrawLine(StringBuilder sb)
        {
            for (int col = 0; col < this.width; col++)
            {
                if (col == 0 || col == this.width - 1)
                {
                    sb.Append("*");
                }
                else
                {
                    sb.Append(" ");
                }
            }

            sb.Append(Environment.NewLine);
        }
    }
}
