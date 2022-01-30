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

        private readonly IDbCommandPerformer _dBService;

        public TargetAudienciesDboRepository(IDbCommandPerformer dBService)
        {
            Items = new List<TargetAudienceDbo>();
            _dBService = dBService;
        }

        public int Create(TargetAudienceDbo dataInstance)
        {
            var storedProcedureName = "[dbo].[CreateTargetAudience]";
            var parameters = new List<SqlParameter>()
            {
                new("Name", DbType.String) { Value = dataInstance.Name }
            };

            return _dBService.PerformScalar(storedProcedureName, parameters);
        }

        public TargetAudienceDbo Read(int id)
        {
            var storedProcedureName = "[dbo].[GetTargetAudienceById]";
            var parameters = new List<SqlParameter>()
            {
                new("Id", DbType.Int32) { Value = id }
            };
            Items = _dBService.PerformStoredProcedure<TargetAudienceDbo>(storedProcedureName, parameters);

            return Items[0];
        }

        public List<TargetAudienceDbo> ReadAll()
        {
            var query = $"SELECT * FROM [dbo].[TargetAudiencies]";
            Items = _dBService.PerformQuery<TargetAudienceDbo>(query, new List<SqlParameter>());

            return Items;
        }

        public int Update(int id, TargetAudienceDbo dataInstance)
        {
            var storedProcedureName = "[dbo].[UpdateTargetAudienceById]";
            var parameters = new List<SqlParameter>()
            {
                new("Id", DbType.Int32) { Value = id },
                new("Name", DbType.String) { Value = dataInstance.Name }
            };

            return _dBService.PerformScalar(storedProcedureName, parameters);
        }

        public int Delete(int id)
        {
            var storedProcedureName = "[dbo].[DeleteTargetAudienceById]";
            var parameters = new List<SqlParameter>()
            {
                new("Id", DbType.Int32) { Value = id }
            };

            try
            {
                return _dBService.PerformScalar(storedProcedureName, parameters);
            }
            catch
            {
                return 0;
            }
        }
    }
}