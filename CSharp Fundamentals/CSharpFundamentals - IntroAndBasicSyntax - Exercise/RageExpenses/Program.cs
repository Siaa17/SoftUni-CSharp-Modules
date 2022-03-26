using System;

namespace RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGamesCount = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            int trashedHeadset = 0;
            int trashedMice = 0;
            int trashedKeyboards = 0;
            int trashedDisplays = 0;

            for (int i = 1; i <= lostGamesCount; i++)
            {
                if (i % 2 == 0)
                {
                    trashedHeadset++;
                }

                if (i % 3 == 0)
                {
                    trashedMice++;
                }

                if (i % 6 == 0)
                {
                    trashedKeyboards++;
                }

                if (i % 12 == 0)
                {
                    trashedDisplays++;
                }
            }

            double rageExpenses = trashedHeadset * headsetPrice + trashedMice * mousePrice +
                trashedKeyboards * keyboardPrice + trashedDisplays * displayPrice;

            Console.WriteLine($"Rage expenses: {rageExpenses:F2} lv.");
        }
    }
}
