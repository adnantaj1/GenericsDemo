using GenericsDemo.Entities;
using System.Linq;

namespace GenericsDemo.Repositories
{
    public class ListRepository<T> : IRepository<T> where T : IEntity
    {
        protected readonly List<T> _items = new();

        public IEnumerable<T> GetAll()
        {
            return _items.ToList();
        }
        public T GetByID(int id) 
        { 
            return _items.Single(item => item.Id == id);
        }
        public void Add(T item) 
        {
            item.Id = _items.Count + 1;
            _items.Add(item);
        }

        public void Remove(T item)
        {
            _items.Remove(item);
        }

        public void save()
        {
            //Everything is saved already in the List<T>
        }
    }
}
