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

        private readonly IDbCommandPerformer _dBService;

        public TestsDboRepository(IDbCommandPerformer dBService)
        {
            Items = new List<TestDbo>();
            _dBService = dBService;
        }

        public int Create(TestDbo dataInstance)
        {
            var storedProcedureName = "[dbo].[CreateTest]";
            var parameters = new List<SqlParameter>()
            {
                new("Name", DbType.String) { Value = dataInstance.Name }
            };

            return _dBService.PerformScalar(storedProcedureName, parameters);
        }

        public TestDbo Read(int id)
        {
            var storedProcedureName = "[dbo].[GetTestById]";
            var parameters = new List<SqlParameter>()
            {
                new("Id", DbType.Int32) { Value = id }
            };
            Items = _dBService.PerformStoredProcedure<TestDbo>(storedProcedureName, parameters);

            return Items[0];
        }

        public List<TestDbo> ReadAll()
        {
            var query = $"SELECT * FROM [dbo].[Tests]";
            Items = _dBService.PerformQuery<TestDbo>(query, new List<SqlParameter>());

            return Items;
        }

        public int Update(int id, TestDbo dataInstance)
        {
            var storedProcedureName = "[dbo].[UpdateTestById]";
            var parameters = new List<SqlParameter>()
            {
                new("Id", DbType.Int32) { Value = id },
                new("Name", DbType.String) { Value = dataInstance.Name }
            };

            return _dBService.PerformScalar(storedProcedureName, parameters);
        }

        public int Delete(int id)
        {
            var storedProcedureName = "[dbo].[DeleteTestById]";
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