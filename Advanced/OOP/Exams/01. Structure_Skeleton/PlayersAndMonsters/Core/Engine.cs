using System;

using PlayersAndMonsters.IO;
using PlayersAndMonsters.IO.Contracts;
using PlayersAndMonsters.Core.Contracts;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private readonly IWriter writer;
        private readonly IReader reader;

        private readonly IManagerController managerController;

        public Engine()
        {
            this.writer = new ConsoleWriter();
            this.reader = new ConsoleReader();

            this.managerController = new ManagerController();
        }

        public void Run()
        {
            while (true)
            {
                var inputParts = this.reader.ReadLine()
                                            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Execute(inputParts);
            }
        }

        private void Execute(string[] inputParts)
        {
            try
            {
                var cmdType = inputParts[0];
                var message = string.Empty;

                if (cmdType == "AddPlayer")
                {
                    var type = inputParts[1];
                    var username = inputParts[2];

                    message = this.managerController.AddPlayer(type, username);
                }
                else if (cmdType == "AddCard")
                {
                    var type = inputParts[1];
                    var name = inputParts[2];

                    message = this.managerController.AddCard(type, name);
                }
                else if (cmdType == "AddPlayerCard")
                {
                    var username = inputParts[1];
                    var cardName = inputParts[2];

                    message = this.managerController.AddPlayerCard(username, cardName);

                }
                else if (cmdType == "Fight")
                {
                    var attackerUsr = inputParts[1];
                    var enemyUsr = inputParts[2];

                    message = this.managerController.Fight(attackerUsr, enemyUsr);
                }
                else if (cmdType == "Report")
                {
                    message = this.managerController.Report();
                }

                if (message != string.Empty)
                {
                    this.writer.WriteLine(message);
                }
            }
            catch (Exception e)
            {
                this.writer.WriteLine(e.Message);
            }
        }
    }
}
