using System;
using System.Linq;

namespace _01.SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Reveal")
            {
                string[] inputParts = input
                    .Split(":|:", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = inputParts[0];

                if (command == "InsertSpace")
                {
                    int index = int.Parse(inputParts[1]);

                    message = message.Insert(index, " ");

                    Console.WriteLine(message);
                }
                else if (command == "Reverse")
                {
                    string substring = inputParts[1];

                    int index = message.IndexOf(substring);

                    if (message.Contains(substring))
                    {
                        message = message.Remove(index, substring.Length);

                        string reversedSubstring = string.Concat(substring.Reverse());

                        message = message + reversedSubstring;
                        //message = message.Insert(index, reversedSubstring);

                        Console.WriteLine(message);
                    }
                    else
                    {
                        Console.WriteLine("error");
                        continue;
                    }
                }
                else if (command == "ChangeAll")
                {
                    string substring = inputParts[1];
                    string replacement = inputParts[2];

                    message = message.Replace(substring, replacement);

                    Console.WriteLine(message);
                }
            }

            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
