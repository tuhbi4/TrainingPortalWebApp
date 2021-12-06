using System.Collections.Generic;

namespace TrainingPortal.DAL.Interfaces
{
    public interface IDboRepository<T> where T : class
    {
        public List<T> Items { get; }

        public int Create(T dataInstance);

        public T Read(int id);

        public List<T> ReadAll();

        public int Update(int id, T dataInstance);

        public int Delete(int id);
    }
}