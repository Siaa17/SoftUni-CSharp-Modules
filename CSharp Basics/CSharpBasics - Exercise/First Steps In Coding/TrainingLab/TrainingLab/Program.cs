using System;

namespace TrainingLab
{
    class Program
    {
        static void Main(string[] args)
        {
            double hInM = double.Parse(Console.ReadLine());
            double wInM = double.Parse(Console.ReadLine());

            double hInCm = hInM * 100;
            double wInCm = (wInM * 100) - 100;

            double checkH = hInCm / 120;
            double checkHResult = Math.Floor(checkH);
            double checkW = wInCm / 70;
            double checkWResult = Math.Floor(checkW);

            double totalDesks = (checkHResult * checkWResult) - 3;

            Console.WriteLine(totalDesks);
                
        }
    }
}
