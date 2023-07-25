﻿using System;

namespace P01ClassBoxData
{
    public class StartUp
    {
        static void Main()
        {
            var length = double.Parse(Console.ReadLine());
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());

            try
            {
                var box = new Box(length, width, height);

                Console.WriteLine($"Surface Area - {box.GetSurfaceArea():F2}");
                Console.WriteLine($"Lateral Surface Area - {box.GetLateralSurfaceArea():F2}");
                Console.WriteLine($"Volume - {box.GetValume():F2}");
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            
        }
    }
}
