using System;

namespace _1.NationalCourt
{
    class Program
    {
        static void Main(string[] args)
        {
            byte peopleCount1 = byte.Parse(Console.ReadLine());
            byte peopleCount2 = byte.Parse(Console.ReadLine());
            byte peopleCount3 = byte.Parse(Console.ReadLine());
            int totalPeopleCount = int.Parse(Console.ReadLine());

            int peoplePerHour = peopleCount1 + peopleCount2 + peopleCount3;

            int hours = 0;

            while (totalPeopleCount > 0)
            {
                hours++;

                if (hours % 4 == 0)
                {
                    continue;
                }

                totalPeopleCount -= peoplePerHour;
            }

            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
