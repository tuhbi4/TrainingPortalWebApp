using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TrainingPortal.DAL.Dbo.CourseItems;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.SqlDAL.Repositories
{
    public class TargetAudienciesDboRepository : IDboRepository<TargetAudienceDbo>
    {
        public List<TargetAudienceDbo> Items { get; set; }

        private const string CreateStoredProcedureName = "[dbo].[CreateTargetAudience]";
        private const string ReadStoredProcedureName = "[dbo].[GetTargetAudienceById]";
        private const string ReadAllQuery = "SELECT* FROM[dbo].[TargetAudiencies]";
        private const string UpdateStoredProcedureName = "[dbo].[UpdateTargetAudienceById]";
        private const string DeleteStoredProcedureName = "[dbo].[DeleteTargetAudienceById]";

        private readonly IDbCommandPerformer dBService;

        public TargetAudienciesDboRepository(IDbCommandPerformer dBService)
        {
            Items = new List<TargetAudienceDbo>();
            this.dBService = dBService;
        }

        public int Create(TargetAudienceDbo dataInstance)
        {
            var storedProcedureName = CreateStoredProcedureName;
            var parameters = new List<SqlParameter>()
            {
                new("Name", DbType.String) { Value = dataInstance.Name }
            };

            return dBService.PerformScalar(storedProcedureName, parameters);
        }

        public TargetAudienceDbo Read(int id)
        {
            var storedProcedureName = ReadStoredProcedureName;
            var parameters = new List<SqlParameter>()
            {
                new("Id", DbType.Int32) { Value = id }
            };
            Items = dBService.PerformStoredProcedure<TargetAudienceDbo>(storedProcedureName, parameters);

            return Items[0];
        }

        public List<TargetAudienceDbo> ReadAll()
        {
            var query = ReadAllQuery;
            Items = dBService.PerformQuery<TargetAudienceDbo>(query, new List<SqlParameter>());

            return Items;
        }

        public int Update(int id, TargetAudienceDbo dataInstance)
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