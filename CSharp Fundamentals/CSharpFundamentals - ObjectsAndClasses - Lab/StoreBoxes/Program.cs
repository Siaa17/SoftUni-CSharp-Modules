using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreBoxes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] dataProduct = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string serialNumber = dataProduct[0];
                string itemName = dataProduct[1];
                int itemQuantity = int.Parse(dataProduct[2]);
                decimal itemPrice = decimal.Parse(dataProduct[3]);

                decimal totalPrice = itemQuantity * itemPrice;

                Box newBox = new Box();

                newBox.SerialNumber = serialNumber;
                newBox.Item = itemName;
                newBox.ItemQuantity = itemQuantity;
                newBox.PricePerBox = itemPrice;
                newBox.TotalPrice = totalPrice;

                boxes.Add(newBox);
            }

            List<Box> sortedBoxes = boxes
                   .OrderByDescending(b => b.TotalPrice)
                   .ToList();

            foreach (Box box in sortedBoxes)
            {
                Console.WriteLine($"{box.SerialNumber}");
                Console.WriteLine($"-- {box.Item} - ${box.PricePerBox:F2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.TotalPrice:F2}");
            }
        }
    }

    class Item
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }

    class Box
    {
        public Box()
        {
            Item item = new Item();
        }

        public string SerialNumber { get; set; }
        public string Item { get; set; }
        public int ItemQuantity { get; set; }
        public decimal PricePerBox { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
