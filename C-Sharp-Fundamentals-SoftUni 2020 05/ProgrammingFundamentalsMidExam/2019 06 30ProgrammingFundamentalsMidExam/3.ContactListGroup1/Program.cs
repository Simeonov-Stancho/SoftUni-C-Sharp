using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _3.ContactListGroup1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> contacts = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<String> commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (commands[0] != "Print")
            {
                if (commands[0] == "Add")
                {
                    string name = commands[1];
                    int index = int.Parse(commands[2]);

                    if (!contacts.Contains(name))
                    {
                        contacts.Add(name);
                    }

                    else if (contacts.Contains(name) && index >= 0 && index < contacts.Count)
                    {
                        contacts.Insert(index, name);
                    }
                }

                else if (commands[0] == "Remove")
                {
                    int index = int.Parse(commands[1]);

                    if (index >= 0 && index < contacts.Count)
                    {
                        contacts.RemoveAt(index);
                    }
                }

                else if (commands[0] == "Export")
                {
                    int startIndex = int.Parse(commands[1]);
                    int count = int.Parse(commands[2]);
                    int endIndex = startIndex + count - 1;
                    List<string> exportContacts = new List<string>();

                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }

                    if (endIndex >= contacts.Count)
                    {
                        endIndex = contacts.Count - 1;
                    }

                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        exportContacts.Add(contacts[i]);
                    }

                    Console.WriteLine(string.Join(" ", exportContacts));
                }

                commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            }

            if (commands[1] == "Normal")
            {
                Console.Write("Contacts: ");
                Console.WriteLine(string.Join(" ", contacts));
            }

            else
            {
                contacts.Reverse();
                Console.Write("Contacts: ");
                Console.WriteLine(string.Join(" ", contacts));
            }
        }
    }
}
