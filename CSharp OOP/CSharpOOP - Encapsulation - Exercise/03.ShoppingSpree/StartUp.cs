using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            try
            {
                ReadPeopleInfo(people);
                ReadProductInfo(products);
            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine(ioe.Message);
                return;
            }

            string line = string.Empty;

            while ((line = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] lineParts = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                    string name = lineParts[0];
                    string purchase = lineParts[1];

                    Person currentPerson = people.FirstOrDefault(p => p.Name == name);
                    Product currentPurchase = products.FirstOrDefault(p => p.Name == purchase);

                    Console.WriteLine(currentPerson.BuyProduct(currentPurchase));
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, people));
        }

        private static void ReadProductInfo(List<Product> products)
        {
            string productInput = Console.ReadLine();

            string[] productArgs = productInput
                    .Split(";", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

            for (int i = 0; i < productArgs.Length; i++)
            {
                string[] parts = productArgs[i]
                    .Split("=", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = parts[0];
                decimal cost = decimal.Parse(parts[1]);

                Product product = new Product(name, cost);
                products.Add(product);
            }
        }

        private static void ReadPeopleInfo(List<Person> people)
        {
            string peopleInput = Console.ReadLine();

            string[] peopleArgs = peopleInput
                    .Split(";", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

            for (int i = 0; i < peopleArgs.Length; i++)
            {
                string[] parts = peopleArgs[i]
                    .Split("=", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = parts[0];
                decimal money = decimal.Parse(parts[1]);

                Person person = new Person(name, money);
                people.Add(person);
            }
        }
    }
}
