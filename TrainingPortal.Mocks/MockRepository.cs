using System.Collections.Generic;
using TrainingPortal.DAL.Interfaces;
using TrainingPortal.Entities;

namespace TrainingPortal.DAL.Mocks
{
    public class MockRepository<T> : IRepository<T> where T : class
    {
        public List<T> Items
        { get { return _list; } }

        private static readonly List<T> _list = typeof(T).Name switch
        {
            nameof(Course) => new MockCourses().List as List<T>,
            nameof(User) => new MockUsers().List as List<T>,
            nameof(Category) => new MockCategories().List as List<T>,
            _ => new List<T>(),
        };

        public void Create(T dataInstance)
        {
            _list.Add(dataInstance);
        }

        public void Delete(int id)
        {
            _list.RemoveAt(id - 1);
        }

        public T Read(int id)
        {
            return _list[id - 1];
        }

        public List<T> ReadAll()
        {
            return _list;
        }

        public void Update(int id, T dataInstance)
        {
            _list[id - 1] = dataInstance;
        }
    }
}