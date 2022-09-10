﻿using System;

namespace Hospital
{
    class Hospital
    {
        static void Main()
        {
            int days = int.Parse(Console.ReadLine());

            int treatedPatients = 0;
            int untreatedPatients = 0;
            int doctors = 7;

            for (int i = 1; i <= days; i++)
            {
                int patients = int.Parse(Console.ReadLine());

                if (untreatedPatients > treatedPatients && i % 3 == 0)
                {
                    doctors++;
                }

                if (patients <= doctors)
                {
                    treatedPatients += patients;
                }
                else
                {
                    treatedPatients += doctors;
                    untreatedPatients += patients - doctors;
                }
            }

            Console.WriteLine($"Treated patients: {treatedPatients}.");
            Console.WriteLine($"Untreated patients: {untreatedPatients}.");
        }
    }
}
