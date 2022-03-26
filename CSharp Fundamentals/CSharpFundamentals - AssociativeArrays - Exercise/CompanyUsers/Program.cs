using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<string>> companies = new SortedDictionary<string, List<string>>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputParts = input
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string companyName = inputParts[0];
                string employeeId = inputParts[1];

                if (!companies.ContainsKey(companyName))
                {
                    companies.Add(companyName, new List<string>());
                }

                companies[companyName].Add(employeeId);
            }

            foreach (KeyValuePair<string, List<string>> company in companies)
            {
                Console.WriteLine(company.Key);

                foreach (string id in company.Value.Distinct())
                {
                    Console.WriteLine($"-- {id}");
                }
            }
        }
    }
}
