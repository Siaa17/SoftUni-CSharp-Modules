using System;
using System.Collections.Generic;
using System.Linq;

namespace ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> usernames = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            foreach (string username in usernames)
            {
                if (isValid(username))
                {
                    Console.WriteLine(username);
                }
            }
        }

        static bool isValid(string username)
        {
            return isValidLength(username) && ContainsValidSymbols(username);
        }

        static bool ContainsValidSymbols(string username)
        {
            foreach (char symbol in username)
            {
                if (!char.IsLetterOrDigit(symbol) &&
                    symbol != '_' &&
                    symbol != '-')
                {
                    return false;
                }
            }

            return true;
        }

        static bool isValidLength(string username)
        {
            return username.Length >= 3 && username.Length <= 16;
        }
    }
}
