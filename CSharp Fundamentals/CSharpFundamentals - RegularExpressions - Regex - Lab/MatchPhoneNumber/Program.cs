using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string phoneNumbers = Console.ReadLine().Trim();

            string pattern = @"\+359( |-)[2]\1\d{3}\1\d{4}\b";

            Regex regex = new Regex(pattern);

            MatchCollection phoneNumsMatches = regex.Matches(phoneNumbers);

            Console.WriteLine(string.Join(", ", phoneNumsMatches));

            //Solution with LINQ methods:
            // + first 4 rows of the code:

            //string[] matchedPhoneNums = phoneNumsMatches
            // .Cast<Match>()
            // .Select(n => n.Value.Trim())
            // .ToArray();

            //Console.WriteLine(string.Join(", ", matchedPhoneNums));


            //Solution with List and foreach loop:
            // + first 4 rows of the code:

            //List<string> phoneNums = new List<string>();

            //foreach (Match match in phoneNumsMatches)
            //{
            //    phoneNums.Add(match.Value.Trim());
            //}

            //Console.WriteLine(string.Join(", ", phoneNumsMatches));
        }
    }
}
