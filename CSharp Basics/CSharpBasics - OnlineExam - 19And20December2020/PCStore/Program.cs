using System;

namespace PCStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double processorPriceInDollars = double.Parse(Console.ReadLine());
            double videoCardPriceInDollars = double.Parse(Console.ReadLine());
            double ramMemoryPriceInDollars = double.Parse(Console.ReadLine());
            int ramMemoryCount = int.Parse(Console.ReadLine());
            double discountPercent = double.Parse(Console.ReadLine());

            double processorPriceInLeva = processorPriceInDollars * 1.57;
            double videoCardPriceInLeva = videoCardPriceInDollars * 1.57;
            double ramMemoryPriceInLeva = ramMemoryPriceInDollars * 1.57;
            double ramtotalPrice = ramMemoryPriceInLeva * ramMemoryCount;
            processorPriceInLeva -= processorPriceInLeva * discountPercent;
            videoCardPriceInLeva -= videoCardPriceInLeva * discountPercent;

            double totalPrice = processorPriceInLeva + videoCardPriceInLeva + ramtotalPrice;

            Console.WriteLine($"Money needed - {totalPrice:F2} leva.");
        }
    }
}
