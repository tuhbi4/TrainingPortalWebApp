using System.Data.SqlClient;

namespace TrainingPortal.DAL.Interfaces
{
    public interface IDboModelMapper
    {
        public T CreateInstance<T>(SqlDataReader reader) where T : class, new();
    }
}