using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, string, bool> startsWithFunc = (name, pattern) => name.StartsWith(pattern);
            Func<string, string, bool> endsWithFunc = (name, pattern) => name.EndsWith(pattern);
            Func<string, int, bool> lengthFunc = (name, length) => name.Length == length;

            List<string> guests = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> filters = new List<string>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Print")
            {
                string[] commandArgs = command
                    .Split(";", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string commandType = commandArgs[0];
                string filterType = commandArgs[1];
                string filterParameter = commandArgs[2];

                if (commandType == "Add filter")
                {
                    filters.Add(filterType + " " + filterParameter);
                }
                else if (commandType == "Remove filter")
                {
                    filters.Remove(filterType + " " + filterParameter);
                }
            }

            foreach (string filter in filters)
            {
                string[] filterArgs = filter
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string filterCondition = filterArgs[0];

                if (filterCondition == "Starts")
                {
                    guests = guests.Where(g => !startsWithFunc(g, filterArgs[2])).ToList();
                }
                else if (filterCondition == "Ends")
                {
                    guests = guests.Where(g => !endsWithFunc(g, filterArgs[2])).ToList();
                }
                else if (filterCondition == "Length")
                {
                    int length = int.Parse(filterArgs[1]);

                    guests = guests.Where(g => !lengthFunc(g, length)).ToList();
                }
                else if (filterCondition == "Contains")
                {
                    string parameter = filterArgs[1];

                    guests = guests.Where(g => !g.Contains(parameter)).ToList();
                }
            }

            if (guests.Count > 0)
            {
                Console.WriteLine(string.Join(" ", guests));
            }
        }
    }
}
