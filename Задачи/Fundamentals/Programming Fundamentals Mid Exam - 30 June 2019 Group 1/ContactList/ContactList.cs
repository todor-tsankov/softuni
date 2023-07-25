using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList
{
    class ContactList
    {
        static void Main(string[] args)
        {
            List<string> contactList = Console.ReadLine().Split().ToList();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Print Normal")
            {
                if (command == "Print Reversed")
                {
                    break;
                }

                string[] commandParts = command.Split();
                string operation = commandParts[0];

                if (operation == "Add")
                {
                    string contact = commandParts[1];
                    int index = int.Parse(commandParts[2]);
                    Add(contact, index, contactList);
                }
                else if (operation == "Remove")
                {
                    int index = int.Parse(commandParts[1]);
                    Remove(index, contactList);
                }
                else if (operation == "Export")
                {
                    int index = int.Parse(commandParts[1]);
                    int count = int.Parse(commandParts[2]);
                    Export(index, count, contactList);
                }
            }

            if (command == "Print Normal")
            {
                Console.Write("Contacts: ");
                Console.WriteLine(string.Join(" ", contactList));
            }
            else if (command == "Print Reversed")
            {
                contactList.Reverse();
                Console.Write("Contacts: ");
                Console.WriteLine(string.Join(" ", contactList));
            }
        }

        static void Add(string contact, int index, List<string> contactList)
        {
            if (index >= 0 && index < contactList.Count)
            {
                if (contactList.Contains(contact))
                {
                    contactList.Insert(index, contact);
                }
                else
                {
                    contactList.Add(contact);
                }
            }
        }

        static void Remove(int index, List<string> contactList)
        {
            if (index >= 0 && index < contactList.Count)
            {
                contactList.RemoveAt(index);
            }
        }

        static void Export(int index, int count, List<string>contactList)
        {
            
            int counter = 0;

            for (int i = index; i < contactList.Count; i++)
            {
                if (counter < count)
                {
                    Console.Write(contactList[i] + " ");
                    counter++;
                }
            }

            Console.WriteLine();
        }
    }
}
