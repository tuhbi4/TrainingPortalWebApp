using System.Collections.Generic;
using TrainingPortal.DAL.Interfaces;
using TrainingPortal.Entities.Models;

namespace TrainingPortal.DAL.Mocks
{
    public class MockRepository<T> : IDboRepository<T> where T : class
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

        public int Create(T dataInstance)
        {
            _list.Add(dataInstance);
            return _list.Count;
        }

        public T Read(int id)
        {
            return _list[id - 1];
        }

        public List<T> ReadAll()
        {
            return _list;
        }

        public int Update(int id, T dataInstance)
        {
            _list[id - 1] = dataInstance;
            return _list.Count;
        }

        public int Delete(int id)
        {
            _list.RemoveAt(id - 1);
            return _list.Count;
        }
    }
}