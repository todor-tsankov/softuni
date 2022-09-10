using System;
using System.Text;
using System.Collections.Generic;

using SpaceStation.IO;
using SpaceStation.IO.Contracts;
using SpaceStation.Core.Contracts;
using System.Linq;

namespace SpaceStation.Core
{
    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private IController controller;

        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
            this.controller = new Controller();
        }
        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    var message = string.Empty;

                    if (input[0] == "AddAstronaut")
                    {
                        var astronautType = input[1];
                        var astronautName= input[2];

                        message = this.controller.AddAstronaut(astronautType, astronautName);
                    }
                    else if (input[0] == "AddPlanet")
                    {
                        var planetName = input[1];

                        var items = input.Skip(2)
                                         .ToArray();

                        message = this.controller.AddPlanet(planetName, items);
                    }
                    else if (input[0] == "RetireAstronaut")
                    {
                        var name = input[1];

                        message = this.controller.RetireAstronaut(name);
                    }
                    else if (input[0] == "ExplorePlanet")
                    {
                        var planetName = input[1];

                        message = this.controller.ExplorePlanet(planetName);
                    }
                    else if(input[0] == "Report")
                    {
                        message = this.controller.Report();
                    }

                    Console.WriteLine(message);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
