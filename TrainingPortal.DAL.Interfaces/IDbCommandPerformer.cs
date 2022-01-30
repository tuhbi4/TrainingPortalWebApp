using System.Collections.Generic;
using System.Data.SqlClient;

namespace TrainingPortal.DAL.Interfaces
{
    public interface IDbCommandPerformer
    {
        public List<T> PerformStoredProcedure<T>(string storedProcedureName, List<SqlParameter> parameters) where T : class;

        public List<T> PerformQuery<T>(string query, List<SqlParameter> parameters) where T : class;

        public int PerformScalar(string storedProcedureName, List<SqlParameter> parameters);
    }
}