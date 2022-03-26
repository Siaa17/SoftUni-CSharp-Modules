using System;

namespace PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            double lightsaberPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            int lightsabersCount = (int)Math.Ceiling(studentsCount * 1.1);
            int beltsCount = studentsCount - studentsCount / 6;

            double totalPrice = lightsaberPrice * lightsabersCount + robePrice * studentsCount + beltPrice * beltsCount;

            if (totalPrice <= budget)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:F2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {(totalPrice - budget):F2}lv more.");
            }
        }
    }
}
