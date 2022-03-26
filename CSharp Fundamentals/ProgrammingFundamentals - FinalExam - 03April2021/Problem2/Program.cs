using System;
using System.Text.RegularExpressions;

namespace Problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string pattern = @"([U][$](?<username>[A-Z][a-z]{2,})[U][$])([P][@][$](?<password>[A-Za-z]{5,}\d+)[P][@][$])";

            int registrationCount = 0;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Regex regex = new Regex(pattern);

                Match match = regex.Match(input);

                if (match.Success)
                {
                    Console.WriteLine("Registration was successful");

                    string username = match.Groups["username"].Value;
                    string password = match.Groups["password"].Value;

                    Console.WriteLine($"Username: {username}, Password: {password}");

                    registrationCount++;
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }
            }

            Console.WriteLine($"Successful registrations: {registrationCount}");
        }
    }
}
