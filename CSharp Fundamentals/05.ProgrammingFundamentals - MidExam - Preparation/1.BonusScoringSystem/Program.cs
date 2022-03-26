using System;

namespace _1.BonusScoringSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            byte studentsCount = byte.Parse(Console.ReadLine());
            byte lecturesCount = byte.Parse(Console.ReadLine());
            byte initialBonus = byte.Parse(Console.ReadLine());

            double maxBonus = 0;
            int maxStudentAttendances = 0;

            for (int i = 0; i < studentsCount; i++)
            {
                int attendances = int.Parse(Console.ReadLine());

                double totalBonus = (attendances * 1.0 / lecturesCount) * (5 + initialBonus);

                if (totalBonus > maxBonus)
                {
                    maxBonus = totalBonus;
                    maxStudentAttendances = attendances;
                }
            }

            Console.WriteLine($"Max Bonus: {Math.Ceiling(maxBonus)}.");
            Console.WriteLine($"The student has attended {maxStudentAttendances} lectures.");
        }
    }
}
