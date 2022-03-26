using System;
using _04.WildFarm.Models.Foods;

namespace _04.WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        private const double WeightGain = 0.30;

        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {           
        }

        public override void Eat(Food food)
        {
            string foodType = food.GetType().Name;

            if (foodType == "Meat" || foodType == "Vegetable")
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
            return "Meow";
        }
    }
}
