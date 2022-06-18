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

        private const string CreateStoredProcedureName = "[dbo].[CreateRole]";
        private const string ReadStoredProcedureName = "[dbo].[GetRoleById]";
        private const string ReadAllQuery = "SELECT* FROM[dbo].[Roles]";
        private const string UpdateStoredProcedureName = "[dbo].[UpdateRoleById]";
        private const string DeleteStoredProcedureName = "[dbo].[DeleteRoleById]";

        private readonly IDbCommandPerformer dBService;

        public RolesDboRepository(IDbCommandPerformer dBService)
        {
            Items = new List<RoleDbo>();
            this.dBService = dBService;
        }

        public int Create(RoleDbo dataInstance)
        {
            var storedProcedureName = CreateStoredProcedureName;
            var parameters = new List<SqlParameter>()
            {
                new("Name", DbType.String) { Value = dataInstance.Name }
            };

            return dBService.PerformScalar(storedProcedureName, parameters);
        }

        public RoleDbo Read(int id)
        {
            var storedProcedureName = ReadStoredProcedureName;
            var parameters = new List<SqlParameter>()
            {
                new("Id", DbType.Int32) { Value = id }
            };
            Items = dBService.PerformStoredProcedure<RoleDbo>(storedProcedureName, parameters);

            return Items[0];
        }

        public List<RoleDbo> ReadAll()
        {
            var query = ReadAllQuery;
            Items = dBService.PerformQuery<RoleDbo>(query, new List<SqlParameter>());

            return Items;
        }

        public int Update(int id, RoleDbo dataInstance)
        {
            var storedProcedureName = UpdateStoredProcedureName;
            var parameters = new List<SqlParameter>()
            {
                new("Id", DbType.Int32) { Value = id },
                new("Name", DbType.String) { Value = dataInstance.Name }
            };

            return dBService.PerformScalar(storedProcedureName, parameters);
        }

        public int Delete(int id)
        {
            var storedProcedureName = DeleteStoredProcedureName;
            var parameters = new List<SqlParameter>()
            {
                new("Id", DbType.Int32) { Value = id }
            };

            try
            {
                return dBService.PerformScalar(storedProcedureName, parameters);
            }
            catch
            {
                return 0;
            }
        }
    }
}