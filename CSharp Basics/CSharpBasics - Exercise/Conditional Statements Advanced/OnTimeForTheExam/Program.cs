using System;

namespace OnTimeForTheExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMinute = int.Parse(Console.ReadLine());
            int arrivalHour = int.Parse(Console.ReadLine());
            int arrivalMinute = int.Parse(Console.ReadLine());

            int examHourInMinutes = examHour * 60 + examMinute;
            int arrivalHourlInMinutes = arrivalHour * 60 + arrivalMinute;

            if (arrivalHourlInMinutes > examHourInMinutes)
            {
                Console.WriteLine("Late");

                int lateInMinutes = arrivalHourlInMinutes - examHourInMinutes;

                if (lateInMinutes < 60)
                {
                    Console.WriteLine($"{lateInMinutes} minutes after the start");
                }
                else
                {
                    int lateHour = lateInMinutes / 60;
                    int lateMinutes = lateInMinutes % 60;

                    Console.WriteLine($"{lateHour}:{lateMinutes:D2} hours after the start");
                }
            }
            else if (arrivalHourlInMinutes == examHourInMinutes || examHourInMinutes - arrivalHourlInMinutes <= 30)
            {
                Console.WriteLine("On time");

                if (arrivalHourlInMinutes != examHourInMinutes)
                {
                    Console.WriteLine($"{examHourInMinutes - arrivalHourlInMinutes} minutes before the start");
                }
            }
            else if (examHourInMinutes - arrivalHourlInMinutes > 30)
            {
                Console.WriteLine("Early");

                int earlyInMinutes = examHourInMinutes - arrivalHourlInMinutes;

                if (earlyInMinutes < 60)
                {
                    Console.WriteLine($"{earlyInMinutes} minutes before the start");
                }
                else
                {
                    int earlyHour = earlyInMinutes / 60;
                    int earlyMinutes = earlyInMinutes % 60;

                    Console.WriteLine($"{earlyHour}:{earlyMinutes:D2} hours before the start");
                }
            }
        }
    }
}
