using System;
using System.Linq;

namespace _01.TheImitationGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Decode")
            {
                string[] inputParts = input
                    .Split("|", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = inputParts[0];

                if (command == "Move")
                {
                    int numOfLetters = int.Parse(inputParts[1]);

                    string firstLetters = message.Substring(0, numOfLetters);

                    message = message.Substring(numOfLetters) + firstLetters;
                }
                else if (command == "Insert")
                {
                    int index = int.Parse(inputParts[1]);
                    string value = inputParts[2];

                    message = message.Insert(index, value);
                }
                else if (command == "ChangeAll")
                {
                    string substring = inputParts[1];
                    string replacement = inputParts[2];

                    while (message.Contains(substring))
                    {
                        message = message.Replace(substring, replacement);
                    }
                }
            }

            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}
