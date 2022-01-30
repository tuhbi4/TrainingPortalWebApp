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

        private readonly IDbCommandPerformer _dBService;

        public QuestionsDboInnerRepository(IDbCommandPerformer dBService)
        {
            Items = new List<TestQuestionDbo>();
            _dBService = dBService;
        }

        public int Create(TestQuestionDbo dataInstance)
        {
            var storedProcedureName = "[dbo].[CreateQuestion]";
            var parameters = new List<SqlParameter>()
            {
                new("TestId", DbType.Int32) { Value = dataInstance.TestId },
                new("Question", DbType.String) { Value = dataInstance.Question }
            };

            return _dBService.PerformScalar(storedProcedureName, parameters);
        }

        public TestQuestionDbo Read(int id)
        {
            var storedProcedureName = "[dbo].[GetQuestionById]";
            var parameters = new List<SqlParameter>()
            {
                new("Id", DbType.Int32) { Value = id }
            };
            Items = _dBService.PerformStoredProcedure<TestQuestionDbo>(storedProcedureName, parameters);

            return Items[0];
        }

        public List<TestQuestionDbo> ReadAllByParentId(int id)
        {
            var storedProcedureName = "[dbo].[GetQuestionsByTestId]";
            var parameters = new List<SqlParameter>()
            {
                new("TestId", DbType.Int32) { Value = id }
            };
            Items = _dBService.PerformStoredProcedure<TestQuestionDbo>(storedProcedureName, parameters);

            return Items;
        }

        public List<TestQuestionDbo> ReadAll()
        {
            var query = $"SELECT * FROM [dbo].[Questions]";
            Items = _dBService.PerformQuery<TestQuestionDbo>(query, new List<SqlParameter>());

            return Items;
        }

        public int Update(int id, TestQuestionDbo dataInstance)
        {
            var storedProcedureName = "[dbo].[UpdateQuestionById]";
            var parameters = new List<SqlParameter>()
            {
                new("Id", DbType.Int32) { Value = id },
                new("TestId", DbType.Int32) { Value = dataInstance.TestId },
                new("Question", DbType.String) { Value = dataInstance.Question }
            };

            return _dBService.PerformScalar(storedProcedureName, parameters);
        }

        public int Delete(int id)
        {
            var storedProcedureName = "[dbo].[DeleteQuestionById]";
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

        public int DeleteAllByParentId(int id)
        {
            var storedProcedureName = "[dbo].[DeleteQuestionsByTestId]";
            var parameters = new List<SqlParameter>()
            {
                new("TestId", DbType.Int32) { Value = id }
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