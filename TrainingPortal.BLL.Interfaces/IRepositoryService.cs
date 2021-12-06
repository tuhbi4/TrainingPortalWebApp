using System.Collections.Generic;

namespace TrainingPortal.BLL.Interfaces
{
    public interface IRepositoryService<T> where T : class
    {
        public int Create(T dataInstance);

        public T Read(int id);

        public List<T> ReadAll();

        public int Update(int id, T dataInstance);

        public int Delete(int id);
    }
}