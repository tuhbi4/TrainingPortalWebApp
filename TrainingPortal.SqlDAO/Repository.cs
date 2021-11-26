using System.Collections.Generic;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.SqlDAL
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public List<T> Items { get; set; }

        public Repository()
        {
            Items = new List<T>();
        }

        public void Create(T dataInstance)
        {
            throw new System.NotImplementedException();
        }

        public T Read(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<T> ReadAll()
        {
            throw new System.NotImplementedException();
        }

        public void Update(int id, T dataInstance)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}