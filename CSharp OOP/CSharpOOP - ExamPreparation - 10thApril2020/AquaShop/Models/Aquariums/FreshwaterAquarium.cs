namespace AquaShop.Models.Aquariums
{
    public class FreshwaterAquarium : Aquarium
    {
        private const int FishwaterAquariumCapacity = 50;

        public FreshwaterAquarium(string name)
            : base(name, FishwaterAquariumCapacity)
        {
        }
    }
}
