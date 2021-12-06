using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TrainingPortal.DAL.Dbo.Models;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.SqlDAL.Repositories
{
    public class RolesDboRepository : IDboRepository<RoleDbo>
    {
        public List<RoleDbo> Items { get; set; }

        private readonly IDbCommandPerformer _dBService;

        public RolesDboRepository(IDbCommandPerformer dBService)
        {
            Items = new List<RoleDbo>();
            _dBService = dBService;
        }

        public int Create(RoleDbo dataInstance)
        {
            var storedProcedureName = "[dbo].[CreateRole]";
            var parameters = new List<SqlParameter>()
            {
                new("Name", DbType.String) { Value = dataInstance.Name }
            };

            return _dBService.PerformNonQuery(storedProcedureName, parameters);
        }

        public RoleDbo Read(int id)
        {
            var storedProcedureName = "[dbo].[GetRoleById]";
            var parameters = new List<SqlParameter>()
            {
                new("Id", DbType.Int32) { Value = id }
            };
            Items = _dBService.PerformStoredProcedure<RoleDbo>(storedProcedureName, parameters);

            return Items[0];
        }

        public List<RoleDbo> ReadAll()
        {
            var query = $"SELECT * FROM [dbo].[Roles]";
            Items = _dBService.PerformQuery<RoleDbo>(query, new List<SqlParameter>());

            return Items;
        }

        public int Update(int id, RoleDbo dataInstance)
        {
            var storedProcedureName = "[dbo].[UpdateRoleById]";
            var parameters = new List<SqlParameter>()
            {
                new("Id", DbType.Int32) { Value = id },
                new("Name", DbType.String) { Value = dataInstance.Name }
            };

            return _dBService.PerformNonQuery(storedProcedureName, parameters);
        }

        public int Delete(int id)
        {
            var storedProcedureName = "[dbo].[DeleteRoleById]";
            var parameters = new List<SqlParameter>()
            {
                new("Id", DbType.Int32) { Value = id }
            };

            try
            {
                return _dBService.PerformNonQuery(storedProcedureName, parameters);
            }
            catch
            {
                return 0;
            }
        }
    }
}