namespace Restaurant
{
    public class Cake : Dessert
    {
        private const decimal DeffaultPrice = 5M;
        private const double DeffaultGrams = 250;
        private const double DeffaultCalories = 1000;

        public Cake(string name)
            : base(name, DeffaultPrice, DeffaultGrams, DeffaultCalories)
        {
        }
    }
}
