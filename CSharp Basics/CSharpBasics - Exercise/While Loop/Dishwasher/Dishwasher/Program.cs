using System;

namespace Dishwasher
{
    class Program
    {
        static void Main(string[] args)
        {
            int detergentBottlesCount = int.Parse(Console.ReadLine());

            int quantityDetergent = detergentBottlesCount * 750;

            int loading = 0;
            int pots = 0;
            int plates = 0;
            bool isDetergentEnough = true;

            string command = Console.ReadLine();

            while (command != "End")
            {
                int dishesCount = int.Parse(command);

                loading++;

                if (loading == 3)
                {
                    pots += dishesCount;
                    dishesCount *= 15;
                    quantityDetergent -= dishesCount;
                    loading = 0;
                }
                else
                {
                    plates += dishesCount;
                    dishesCount *= 5;
                    quantityDetergent -= dishesCount;
                }

                if (quantityDetergent < 0)
                {
                    isDetergentEnough = false;
                    break;
                }

                command = Console.ReadLine();
            }

            if (isDetergentEnough)
            {
                Console.WriteLine("Detergent was enough!");
                Console.WriteLine($"{plates} dishes and {pots} pots were washed.");
                Console.WriteLine($"Leftover detergent {quantityDetergent} ml.");
            }
            else
            {
                Console.WriteLine($"Not enough detergent, {Math.Abs(quantityDetergent)} ml. more necessary!");
            }
        }
    }
}
