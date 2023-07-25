using ViceCity.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.IO.Contracts;
using ViceCity.IO;

namespace ViceCity.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IController controller;

        public Engine()
        {
            this.reader = new Reader();
            this.writer = new Writer();
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

                    if (input[0] == "AddPlayer")
                    {
                        var name = input[1];

                        message = this.controller.AddPlayer(name);
                    }
                    else if (input[0] == "AddGun")
                    {
                        var type = input[1];
                        var name = input[2];

                        message = this.controller.AddGun(type, name);
                    }
                    else if (input[0] == "AddGunToPlayer")
                    {
                        var name = input[1];

                        message = this.controller.AddGunToPlayer(name);
                    }
                    else if (input[0] == "Fight")
                    {
                        message = this.controller.Fight();
                    }

                    writer.WriteLine(message);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
