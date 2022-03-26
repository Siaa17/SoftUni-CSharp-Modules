using System;

namespace _1.SoftUniReception
{
    class Program
    {
        static void Main(string[] args)
        {
            byte studentsCount1 = byte.Parse(Console.ReadLine());
            byte studentsCount2 = byte.Parse(Console.ReadLine());
            byte studentsCount3 = byte.Parse(Console.ReadLine());
            int totalStudentsCount = int.Parse(Console.ReadLine());

            int studentsPerHour = studentsCount1 + studentsCount2 + studentsCount3;

            int hours = 0;

            while (totalStudentsCount > 0)
            {
                hours++;

                if (hours % 4 == 0)
                {
                    continue;
                }

                totalStudentsCount -= studentsPerHour;
            }

            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
