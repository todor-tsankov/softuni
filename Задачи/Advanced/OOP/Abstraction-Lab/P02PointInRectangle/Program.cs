using System;
using System.Linq;

namespace P02PointInRectangle
{
    public class Program
    {
        static void Main()
        {
            var rectangleInfo = ReadCoordinates();

            var topLeftX = Math.Min(rectangleInfo[0], rectangleInfo[2]);
            var topLeftY = Math.Max(rectangleInfo[1], rectangleInfo[3]);

            var bottomRightX = Math.Max(rectangleInfo[0], rectangleInfo[2]);
            var bottomRightY = Math.Min(rectangleInfo[1], rectangleInfo[3]);

            var topLeft = new Point(topLeftX, topLeftY);
            var bottomRight = new Point(bottomRightX, bottomRightY);

            var rectangle = new Rectangle(topLeft, bottomRight);

            var numberOfLines = int.Parse(Console.ReadLine());
            CheckPoints(rectangle, numberOfLines);
        }

        private static void CheckPoints(Rectangle rectangle, int numberOfLines)
        {
            for (int i = 0; i < numberOfLines; i++)
            {
                var pointCoordinates = ReadCoordinates();
                var point = new Point(pointCoordinates[0], pointCoordinates[1]);

                Console.WriteLine(rectangle.Contains(point));
            }
        }

        private static int[] ReadCoordinates()
        {
            return Console.ReadLine()
                          .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                          .Select(int.Parse)
                          .ToArray();
        }
    }
}
