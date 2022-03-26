using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
           
            double neededMoney = double.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());

            int daysOfSpending = 0;
            int daysCounter = 0;
            bool isManaged = true;

            while (budget < neededMoney)
            {
                string command = Console.ReadLine();
                double sum = double.Parse(Console.ReadLine());

                daysCounter++;
                
                if (command == "spend")
                {
                    daysOfSpending++;

                    if (daysOfSpending == 5)
                    {
                        isManaged = false;
                        break;
                    }

                    budget -= sum;

                    if (budget < 0)
                    {
                        budget = 0;
                    }
                }
                else if (command == "save")
                {
                    daysOfSpending = 0;
                    budget += sum;
                }
            }

            if (isManaged)
            {
                Console.WriteLine($"You saved the money for {daysCounter} days.");
            }
            else
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine($"{daysCounter}");
            }
        }
    }
}
