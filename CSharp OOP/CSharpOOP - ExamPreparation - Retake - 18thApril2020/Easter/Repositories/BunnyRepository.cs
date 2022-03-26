using System.Collections.Generic;
using System.Linq;
using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private readonly List<IBunny> bunnies;

        public BunnyRepository()
        {
            this.bunnies = new List<IBunny>();
        }

        public IReadOnlyCollection<IBunny> Models => this.bunnies.AsReadOnly();

        public void Add(IBunny model) => this.bunnies.Add(model);

        public IBunny FindByName(string name) => this.bunnies.FirstOrDefault(b => b.Name == name);

        public bool Remove(IBunny model) => this.bunnies.Remove(model);
    }
}
