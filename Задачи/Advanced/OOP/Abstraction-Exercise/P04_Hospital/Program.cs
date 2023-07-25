using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        public static void Main()
        {
            var doctors = new Dictionary<string, List<string>>();
            var departments = new Dictionary<string, List<List<string>>>();

            ProcessPatients(doctors, departments);
            PrintResultsAccordingToFilters(doctors, departments);
        }

        private static void PrintResultsAccordingToFilters(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments)
        {
            var command = Console.ReadLine();

            while (command != "End")
            {
                var printInfo = command.Split();

                var result = ResultSwitch(doctors, departments, printInfo);
                Console.WriteLine(result);

                command = Console.ReadLine();
            }
        }

        private static string ResultSwitch(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments, string[] printInfo)
        {
            string result;
            if (printInfo.Length == 1)
            {
                result = string.Join("\n", departments[printInfo[0]].Where(x => x.Count > 0).SelectMany(x => x));
            }
            else if (printInfo.Length == 2 && int.TryParse(printInfo[1], out int room))
            {
                result = string.Join("\n", departments[printInfo[0]][room - 1].OrderBy(x => x));
            }
            else
            {
                result = string.Join("\n", doctors[printInfo[0] + printInfo[1]].OrderBy(x => x));
            }

            return result;
        }

        private static void ProcessPatients(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments)
        {
            var command = Console.ReadLine();

            while (command != "Output")
            {
                var personInfo = command.Split();

                var departament = personInfo[0];

                var doctorFirstName = personInfo[1];
                var doctorSecondName = personInfo[2];

                var patient = personInfo[3];
                var doctorFullName = doctorFirstName + doctorSecondName;

                AddDoctorIfNeeded(doctors, doctorFirstName, doctorSecondName, doctorFullName);
                AddDepartmentIfNeeded(departments, departament);

                bool hasPlace = departments[departament].SelectMany(x => x).Count() < 60;

                AddPatientIfPossible(doctors, departments, departament, patient, doctorFullName, hasPlace);

                command = Console.ReadLine();
            }
        }

        private static void AddPatientIfPossible(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments, string departament, string patient, string doctorFullName, bool hasPlace)
        {
            if (hasPlace)
            {
                int roomAvailable = 0;
                doctors[doctorFullName].Add(patient);

                roomAvailable = FindFreeRoom(departments, departament, roomAvailable);
                departments[departament][roomAvailable].Add(patient);
            }
        }

        private static int FindFreeRoom(Dictionary<string, List<List<string>>> departments, string departament, int roomAvailable)
        {
            for (int currentRoom = 0; currentRoom < departments[departament].Count; currentRoom++)
            {
                if (departments[departament][currentRoom].Count < 3)
                {
                    roomAvailable = currentRoom;

                    break;
                }
            }

            return roomAvailable;
        }

        private static void AddDepartmentIfNeeded(Dictionary<string, List<List<string>>> departments, string departament)
        {
            if (!departments.ContainsKey(departament))
            {
                departments[departament] = new List<List<string>>();

                for (int room = 0; room < 20; room++)
                {
                    departments[departament].Add(new List<string>());
                }
            }
        }

        private static void AddDoctorIfNeeded(Dictionary<string, List<string>> doctors, string doctorFirstName, string doctorSecondName, string doctorFullName)
        {
            if (!doctors.ContainsKey(doctorFirstName + doctorSecondName))
            {
                doctors[doctorFullName] = new List<string>();
            }
        }
    }
}
