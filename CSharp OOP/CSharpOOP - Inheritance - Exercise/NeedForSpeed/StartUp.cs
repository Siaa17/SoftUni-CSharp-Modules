using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Vehicle motorcycle = new Vehicle(300, 100);

            motorcycle.Drive(120);
        }
    }
}
