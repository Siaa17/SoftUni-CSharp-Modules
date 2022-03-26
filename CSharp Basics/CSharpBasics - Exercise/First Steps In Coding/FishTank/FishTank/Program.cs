using System;

namespace FishTank
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());

            double volumeInCm = (lenght * width * height);
            double volumeInDm = volumeInCm * 0.001;
            double netVolume = volumeInDm - (volumeInDm * (percent / 100));

            Console.WriteLine(netVolume);

        }
    }
}
