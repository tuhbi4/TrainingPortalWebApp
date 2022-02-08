using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TrainingPortal.DAL.Dbo.CourseItems;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.SqlDAL.Repositories
{
    public class TestsDboRepository : IDboRepository<TestDbo>
    {
        public List<TestDbo> Items { get; set; }

        private const string CreateStoredProcedureName = "[dbo].[CreateTest]";
        private const string ReadStoredProcedureName = "[dbo].[GetTestById]";
        private const string ReadAllQuery = "SELECT* FROM[dbo].[Tests]";
        private const string UpdateStoredProcedureName = "[dbo].[UpdateTestById]";
        private const string DeleteStoredProcedureName = "[dbo].[DeleteTestById]";

        private readonly IDbCommandPerformer dBService;

        public TestsDboRepository(IDbCommandPerformer dBService)
        {
            Items = new List<TestDbo>();
            this.dBService = dBService;
        }

        public int Create(TestDbo dataInstance)
        {
            var storedProcedureName = CreateStoredProcedureName;
            var parameters = new List<SqlParameter>()
            {
                new("Name", DbType.String) { Value = dataInstance.Name }
            };

            return dBService.PerformScalar(storedProcedureName, parameters);
        }

        public TestDbo Read(int id)
        {
            var storedProcedureName = ReadStoredProcedureName;
            var parameters = new List<SqlParameter>()
            {
                new("Id", DbType.Int32) { Value = id }
            };
            Items = dBService.PerformStoredProcedure<TestDbo>(storedProcedureName, parameters);

            return Items[0];
        }

        public List<TestDbo> ReadAll()
        {
            var query = ReadAllQuery;
            Items = dBService.PerformQuery<TestDbo>(query, new List<SqlParameter>());

            return Items;
        }

        public int Update(int id, TestDbo dataInstance)
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