using System;
using System.Collections.Generic;
using System.Linq;

namespace P03MessagesManager
{
    class P03MessagesManager
    {
        static void Main(string[] args)
        {
            Dictionary<string, Messages> users = new Dictionary<string, Messages>();

            int capacity = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            while (command != "Statistics")
            {
                string[] commandArgs = command.Split('=');
                string commandType = commandArgs[0];

                if (commandType == "Add")
                {
                    AddUser(users, commandArgs);
                }
                else if (commandType == "Message")
                {
                    AddMessage(users, capacity, commandArgs);
                }
                else if (commandType == "Empty")
                {
                    RemoveUser(users, commandArgs);
                }

                command = Console.ReadLine();
            }

            Print(users);
        }

        private static void RemoveUser(Dictionary<string, Messages> users, string[] commandArgs)
        {
            string username = commandArgs[1];

            if (username == "All")
            {
                users.Clear();
            }
            else
            {
                users.Remove(username);
            }
        }

        private static void AddMessage(Dictionary<string, Messages> users, int capacity, string[] commandArgs)
        {
            string sender = commandArgs[1];
            string reciever = commandArgs[2];

            if (users.ContainsKey(sender) && users.ContainsKey(reciever))
            {
                users[sender].Sent++;
                users[reciever].Recieved++;

                if (users[sender].Total >= capacity)
                {
                    users.Remove(sender);

                    Console.WriteLine($"{sender} reached the capacity!");
                }

                if (users[reciever].Total >= capacity)
                {
                    users.Remove(reciever);

                    Console.WriteLine($"{reciever} reached the capacity!");
                }
            }
        }

        private static void AddUser(Dictionary<string, Messages> users, string[] commandArgs)
        {
            string username = commandArgs[1];

            if (!users.ContainsKey(username))
            {
                int sent = int.Parse(commandArgs[2]);
                int recieved = int.Parse(commandArgs[3]);

                users.Add(username, new Messages(sent, recieved));
            }
        }

        static void Print(Dictionary<string, Messages> users)
        {
            Console.WriteLine($"Users count: {users.Count}");

            var sortedUsers = users.OrderByDescending(i => i.Value.Recieved).ThenBy(i => i.Key);

            foreach (var user in sortedUsers)
            {
                int countRecievedSent = user.Value.Recieved + user.Value.Sent;

                Console.WriteLine($"{user.Key} - {countRecievedSent}");
            }
        }
    }

    class Messages
    {
        public Messages(int sent = 0, int recieved = 0)
        {
            Sent = sent;
            Recieved = recieved;
        }
        public int Sent { get; set; }
        public int Recieved { get; set; }

        public int Total => this.Sent + this.Recieved;
    }
}
