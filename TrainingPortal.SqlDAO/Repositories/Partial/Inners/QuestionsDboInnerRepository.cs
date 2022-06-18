using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TrainingPortal.DAL.Dbo.CourseItems.TestItems;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.SqlDAL.Repositories
{
    public class QuestionsDboInnerRepository : IDboInnerRepository<TestQuestionDbo>
    {
        public List<TestQuestionDbo> Items { get; set; }

        private const string CreateStoredProcedureName = "[dbo].[CreateQuestion]";
        private const string ReadStoredProcedureName = "[dbo].[GetQuestionById]";
        private const string ReadAllByParentIdStoredProcedureName = "[dbo].[GetQuestionsByTestId]";
        private const string ReadAllQuery = "SELECT* FROM[dbo].[Questions]";
        private const string UpdateStoredProcedureName = "[dbo].[UpdateQuestionById]";
        private const string DeleteStoredProcedureName = "[dbo].[DeleteQuestionById]";
        private const string DeleteAllByParentIdStoredProcedureName = "[dbo].[DeleteQuestionsByTestId]";

        private readonly IDbCommandPerformer dBService;

        public QuestionsDboInnerRepository(IDbCommandPerformer dBService)
        {
            Items = new List<TestQuestionDbo>();
            this.dBService = dBService;
        }

        public int Create(TestQuestionDbo dataInstance)
        {
            var storedProcedureName = CreateStoredProcedureName;
            var parameters = new List<SqlParameter>()
            {
                new("TestId", DbType.Int32) { Value = dataInstance.TestId },
                new("Question", DbType.String) { Value = dataInstance.Question }
            };

            return dBService.PerformScalar(storedProcedureName, parameters);
        }

        public TestQuestionDbo Read(int id)
        {
            var storedProcedureName = ReadStoredProcedureName;
            var parameters = new List<SqlParameter>()
            {
                new("Id", DbType.Int32) { Value = id }
            };
            Items = dBService.PerformStoredProcedure<TestQuestionDbo>(storedProcedureName, parameters);

            return Items[0];
        }

        public List<TestQuestionDbo> ReadAllByParentId(int id)
        {
            var storedProcedureName = ReadAllByParentIdStoredProcedureName;
            var parameters = new List<SqlParameter>()
            {
                new("TestId", DbType.Int32) { Value = id }
            };
            Items = dBService.PerformStoredProcedure<TestQuestionDbo>(storedProcedureName, parameters);

            return Items;
        }

        public List<TestQuestionDbo> ReadAll()
        {
            var query = ReadAllQuery;
            Items = dBService.PerformQuery<TestQuestionDbo>(query, new List<SqlParameter>());

            return Items;
        }

        public int Update(int id, TestQuestionDbo dataInstance)
        {
            var storedProcedureName = UpdateStoredProcedureName;
            var parameters = new List<SqlParameter>()
            {
                new("Id", DbType.Int32) { Value = id },
                new("TestId", DbType.Int32) { Value = dataInstance.TestId },
                new("Question", DbType.String) { Value = dataInstance.Question }
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

        public int DeleteAllByParentId(int id)
        {
            var storedProcedureName = DeleteAllByParentIdStoredProcedureName;
            var parameters = new List<SqlParameter>()
            {
                new("TestId", DbType.Int32) { Value = id }
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