using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredicateParty_
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> lengthFunc = (name, length) => name.Length == length;
            Func<string, string, bool> startsWithFunc = (name, pattern) => name.StartsWith(pattern);
            Func<string, string, bool> endsWithFunc = (name, pattern) => name.EndsWith(pattern);

            List<string> partyPeople = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Party!")
            {
                string[] commandArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string commandType = commandArgs[0];
                string condition = commandArgs[1];
                string parameter = commandArgs[2];

                if (commandType == "Double")
                {
                    if (condition == "Length")
                    {
                        int length = int.Parse(parameter);

                        List<string> tempNames = partyPeople.Where(p => lengthFunc(p, length)).ToList();

                        MyAddRange(partyPeople, tempNames);
                    }
                    else if (condition == "StartsWith")
                    {
                        List<string> tempNames = partyPeople.Where(p => startsWithFunc(p, parameter)).ToList();

                        MyAddRange(partyPeople, tempNames);
                    }
                    else if (condition == "EndsWith")
                    {
                        List<string> tempNames = partyPeople.Where(p => endsWithFunc(p, parameter)).ToList();

                        MyAddRange(partyPeople, tempNames);
                    }
                }
                else if (commandType == "Remove")
                {
                    if (condition == "Length")
                    {
                        int length = int.Parse(parameter);

                        partyPeople = partyPeople.Where(p => !lengthFunc(p, length)).ToList();
                    }
                    else if (condition == "StartsWith")
                    {
                        partyPeople = partyPeople.Where(p => !startsWithFunc(p, parameter)).ToList();
                    }
                    else if (condition == "EndsWith")
                    {
                        partyPeople = partyPeople.Where(p => !endsWithFunc(p, parameter)).ToList();
                    }
                }
            }

            if (partyPeople.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", partyPeople)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        static void MyAddRange(List<string> partyPeople, List<string> tempNames)
        {
            foreach (string currentName in tempNames)
            {
                int index = partyPeople.IndexOf(currentName);

                partyPeople.Insert(index, currentName);
            }
        }
    }
}
