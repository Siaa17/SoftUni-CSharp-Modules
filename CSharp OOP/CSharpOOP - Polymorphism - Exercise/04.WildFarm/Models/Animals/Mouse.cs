using System;
using _04.WildFarm.Models.Foods;

namespace _04.WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {
        private const double WeightGain = 0.10;

        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override void Eat(Food food)
        {
            string foodType = food.GetType().Name;

            if (foodType == "Vegetable" || foodType == "Fruit")
            {
                this.Weight += food.Quantity * WeightGain;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {foodType}!");
            }
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
