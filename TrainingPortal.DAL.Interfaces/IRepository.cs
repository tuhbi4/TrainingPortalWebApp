using System.Collections.Generic;

namespace TrainingPortal.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public List<T> Items { get; }

        public void Create(T dataInstance);

        public T Read(int id);

        public List<T> ReadAll();

        public void Update(int id, T dataInstance);

        public void Delete(int id);
    }
}