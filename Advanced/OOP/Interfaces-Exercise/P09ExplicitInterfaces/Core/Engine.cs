using System;
using System.Linq;
using ExplicitInterfaces.Models;
using ExplicitInterfaces.Contracts;
using ExplicitInterfaces.IO.Contracts;

namespace ExplicitInterfaces.Core
{
    public class Engine
    {
        private IReadable reader;
        private IWritable writer;

        public Engine(IReadable reader, IWritable writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            while (true)
            {
                var residentInfo = this.reader.ReadLine();

                if (residentInfo == "End")
                {
                    break;
                }

                var residentInfoArgs = residentInfo.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                                   .ToArray();

                var name = residentInfoArgs[0];
                var country = residentInfoArgs[1];
                var age = int.Parse(residentInfoArgs[2]);

                try
                {
                    var citizen = new Citizen(name, country, age);

                    IPerson person = citizen;
                    IResident resident = citizen;

                    this.writer.WriteLine(person.GetName());
                    this.writer.WriteLine(resident.GetName());
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
