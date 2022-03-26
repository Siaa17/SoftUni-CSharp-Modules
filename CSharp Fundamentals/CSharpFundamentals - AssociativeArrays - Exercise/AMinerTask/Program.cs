using System;
using System.Collections.Generic;
using System.Linq;

namespace AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> quantityByResource = new Dictionary<string, int>();

            string resource = string.Empty;

            while ((resource = Console.ReadLine()) != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());

                if (quantityByResource.ContainsKey(resource))
                {
                    quantityByResource[resource] += quantity;
                }
                else
                {
                    quantityByResource.Add(resource, quantity);
                }
            }

            foreach (KeyValuePair<string, int> item in quantityByResource)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
