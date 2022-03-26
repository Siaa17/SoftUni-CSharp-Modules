using System.Collections.Generic;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public abstract class Repository<T> : IRepository<T>
    {
        protected Repository()
        {
            this.Models = new List<T>();
        }

        public ICollection<T> Models { get; }

        public void Add(T model) => this.Models.Add(model);

        public IReadOnlyCollection<T> GetAll() => this.Models as IReadOnlyCollection<T>;

        public abstract T GetByName(string name);

        public bool Remove(T model) => this.Models.Remove(model);
    }
}
