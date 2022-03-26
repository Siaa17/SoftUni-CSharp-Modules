using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();

            list.Add("Bianka");
            list.Add("Ari");
            list.Add("Vesi");
            list.Add("Sisi");
            list.Add("Peti");
            list.Add("Vanko");

            Console.WriteLine(list.RandomString());
        }
    }
}
