using System.Collections.Generic;

namespace TrainingPortal.BLL.Interfaces
{
    public interface IRepositoryService<T> where T : class
    {
        public void Create(T dataInstance);

        public T Read(int id);

        public List<T> ReadAll();

        public void Update(int id, T dataInstance);

        public void Delete(int id);
    }
}