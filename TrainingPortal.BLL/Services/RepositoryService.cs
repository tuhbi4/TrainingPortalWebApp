using System.Collections.Generic;
using TrainingPortal.BLL.Interfaces;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.BLL.Services
{
    public class RepositoryService<T> : IRepositoryService<T> where T : class
    {
        private readonly IRepository<T> repository;

        public RepositoryService(IRepository<T> repository)
        {
            this.repository = repository;
        }

        public void Create(T dataInstance)
        {
            repository.Create(dataInstance);
        }

        public T Read(int id)
        {
            return repository.Read(id);
        }

        public List<T> ReadAll()
        {
            return repository.ReadAll();
        }

        public void Update(int id, T dataInstance)
        {
            repository.Update(id, dataInstance);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }
    }
}