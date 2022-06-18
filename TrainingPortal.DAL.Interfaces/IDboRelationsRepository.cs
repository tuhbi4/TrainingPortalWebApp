using System.Collections.Generic;

namespace TrainingPortal.DAL.Interfaces
{
    public interface IDboRelationsRepository<T> : IDboRepository<T> where T : class
    {
        public new List<T> Read(int id);

        public int Delete(T dataInstance);
    }
}