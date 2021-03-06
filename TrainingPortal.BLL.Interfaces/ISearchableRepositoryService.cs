using System.Collections.Generic;

namespace TrainingPortal.BLL.Interfaces
{
    public interface ISearchableRepositoryService<T> : IRepositoryService<T> where T : class
    {
        public List<T> Search(string courseName, string categoryName, string targetAudiencyName);
    }
}