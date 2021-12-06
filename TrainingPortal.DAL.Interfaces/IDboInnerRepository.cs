using System.Collections.Generic;

namespace TrainingPortal.DAL.Interfaces
{
    public interface IDboInnerRepository<T> : IDboRepository<T> where T : class
    {
        public List<T> ReadAllByParentId(int id);

        public int DeleteAllByParentId(int id);
    }
}