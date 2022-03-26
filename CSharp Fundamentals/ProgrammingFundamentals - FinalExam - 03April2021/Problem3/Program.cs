using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem3
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> emailsByUser = new Dictionary<string, List<string>>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] inputParts = input
                    .Split("->", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = inputParts[0];
                string username = inputParts[1];

                if (command == "Add")
                {
                    if (!emailsByUser.ContainsKey(username))
                    {
                        emailsByUser.Add(username, new List<string>());
                    }
                    else
                    {
                        Console.WriteLine($"{username} is already registered");
                    }
                }
                else if (command == "Send")
                {
                    string email = inputParts[2];

                    emailsByUser[username].Add(email);
                }
                else if (command == "Delete")
                {
                    if (emailsByUser.ContainsKey(username))
                    {
                        emailsByUser.Remove(username);
                    }
                    else
                    {
                        Console.WriteLine($"{username} not found!");
                    }
                }
            }

            Console.WriteLine($"Users count: {emailsByUser.Count}");

            Dictionary<string, List<string>> sorted = emailsByUser
                .OrderByDescending(u => u.Value.Count)
                .ThenBy(u => u.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in sorted)
            {
                string username = kvp.Key;
                List<string> emails = kvp.Value;

                Console.WriteLine(username);

                foreach (var email in emails)
                {
                    Console.WriteLine($"- {email}");
                }
            }
        }
    }
}
