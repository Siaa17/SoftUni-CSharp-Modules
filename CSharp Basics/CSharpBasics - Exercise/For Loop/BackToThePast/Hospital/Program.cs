using System;

namespace Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            
            int countDoctors = 7;
            int treatedPatients = 0;
            int untreatedPatients = 0;
            
            for (int i = 1; i <= days; i++)
            {
                if (i % 3 == 0)
                {
                    if (untreatedPatients > treatedPatients)
                    {
                        countDoctors++;
                    }
                }

                int patientsPerDay = int.Parse(Console.ReadLine());
                if (patientsPerDay <= countDoctors)
                {
                    treatedPatients += patientsPerDay;
                }
                else
                {
                    treatedPatients += countDoctors;
                    untreatedPatients += patientsPerDay - countDoctors;
                }
            }

            Console.WriteLine($"Treated patients: {treatedPatients}.");
            Console.WriteLine($"Untreated patients: {untreatedPatients}.");
        }
    }
}
