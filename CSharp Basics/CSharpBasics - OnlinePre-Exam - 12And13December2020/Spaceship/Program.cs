using System;

namespace Spaceship
{
    class Program
    {
        static void Main(string[] args)
        {
            double shipWidth = double.Parse(Console.ReadLine());
            double shipLength = double.Parse(Console.ReadLine());
            double shipHeight = double.Parse(Console.ReadLine());
            double astronautsAverageHeight = double.Parse(Console.ReadLine());

            double shipVolume = shipWidth * shipLength * shipHeight;
            double roomVolume = (astronautsAverageHeight + 0.40) * 2 * 2;
            double astrounautsCount = shipVolume / roomVolume;

            if (astrounautsCount >= 3 && astrounautsCount <= 10)
            {
                Console.WriteLine($"The spacecraft holds {Math.Floor(astrounautsCount)} astronauts.");
            }
            else if (astrounautsCount < 3)
            {
                Console.WriteLine("The spacecraft is too small.");
            }
            else if (astrounautsCount > 10)
            {
                Console.WriteLine("The spacecraft is too big.");
            }
        }
    }
}
