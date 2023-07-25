using System.Linq;
using System.Collections.Generic;

using MilitaryElite.Models;
using MilitaryElite.IO.Contracts;
using MilitaryElite.Core.Contracts;
using MilitaryElite.Enumerations;

namespace MilitaryElite.Core
{
    public class Engine : IEngine
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
            var soldierList = new List<Soldier>();

            while (true)
            {
                var command = reader.ReadLine();

                if (command == "End")
                {
                    break;
                }

                var soldierInfoArgs = command.Split()
                                             .ToArray();

                var soldierType = soldierInfoArgs[0];
                var id = soldierInfoArgs[1];

                Soldier current = null;

                if (soldierType == "Private")
                {
                    current = CreatePrivate(soldierInfoArgs, id);
                }
                else if (soldierType == "LieutenantGeneral")
                {
                    current = CreateLieutenanet(soldierList, soldierInfoArgs, id);
                }
                else if (soldierType == "Engineer")
                {
                    current = CreateEngineer(soldierInfoArgs, id);
                }
                else if (soldierType == "Commando")
                {
                    current = CreateCommando(soldierInfoArgs, id);
                }
                else if (soldierType == "Spy")
                {
                    current = CreateSpy(soldierInfoArgs, id);
                }

                if (current != null)
                {
                    soldierList.Add(current);
                }
            }

            Print(soldierList);
        }

        private void Print(List<Soldier> soldierList)
        {
            foreach (var pr in soldierList)
            {
                writer.WriteLine(pr.ToString());
            }
        }

        private Soldier CreateCommando(string[] soldierInfoArgs, string id)
        {
            Soldier current;
            var firstName = soldierInfoArgs[2];
            var lastName = soldierInfoArgs[3];
            var salary = decimal.Parse(soldierInfoArgs[4]);

            var corpsString = soldierInfoArgs[5];

            var success = Corps.TryParse(corpsString, out Corps corps);

            if (!success)
            {
                return null;
            }

            var missionsInputArr = soldierInfoArgs.Skip(6)
                                                  .ToArray();
            var missions = new List<Mission>();

            for (int i = 0; i < missionsInputArr.Length; i += 2)
            {
                var missionCodeName = missionsInputArr[i];

                var successMission = State.TryParse(missionsInputArr[i + 1], out State missionState);

                if (successMission)
                {
                    var currentRepair = new Mission(missionCodeName, missionState);

                    missions.Add(currentRepair);
                }
            }


            current = new Commando(id, firstName, lastName, salary, corps, missions);
            return current;
        }

        private Soldier CreateEngineer(string[] soldierInfoArgs, string id)
        {
            Soldier current;
            var firstName = soldierInfoArgs[2];
            var lastName = soldierInfoArgs[3];
            var salary = decimal.Parse(soldierInfoArgs[4]);

            var corpsString = soldierInfoArgs[5];

            var success = Corps.TryParse(corpsString, out Corps corps);

            if (!success)
            {
                return null;
            }

            var repairsInputArr = soldierInfoArgs.Skip(6)
                                                 .ToArray();
            var repairs = new List<Repair>();

            for (int i = 0; i < repairsInputArr.Length; i += 2)
            {
                var repairPart = repairsInputArr[i];
                var hours = int.Parse(repairsInputArr[i + 1]);

                var currentRepair = new Repair(repairPart, hours);

                repairs.Add(currentRepair);
            }

            current = new Engineer(id, firstName, lastName, salary, corps, repairs);
            return current;
        }

        private Soldier CreateSpy(string[] soldierInfoArgs, string id)
        {
            Soldier current;
            var firstName = soldierInfoArgs[2];
            var lastName = soldierInfoArgs[3];
            var codeNumber = int.Parse(soldierInfoArgs[4]);

            current = new Spy(id, firstName, lastName, codeNumber);
            return current;
        }

        private Soldier CreateLieutenanet(List<Soldier> soldierList, string[] soldierInfoArgs, string id)
        {
            Soldier current;
            var firstName = soldierInfoArgs[2];
            var lastName = soldierInfoArgs[3];
            var salary = decimal.Parse(soldierInfoArgs[4]);

            var privateIds = soldierInfoArgs.Skip(5);
            var privatesList = new List<Private>();

            foreach (var currentId in privateIds)
            {
                var @private = (Private) soldierList.First(p => p.Id == currentId);

                privatesList.Add(@private);
            }

            current = new LieutenantGeneral(id, firstName, lastName, salary, privatesList);
            return current;
        }

        private static Soldier CreatePrivate(string[] soldierInfoArgs, string id)
        {
            Soldier current;
            var firstName = soldierInfoArgs[2];
            var lastName = soldierInfoArgs[3];
            var salary = decimal.Parse(soldierInfoArgs[4]);

            current = new Private(id, firstName, lastName, salary);
            return current;
        }
    }
}
