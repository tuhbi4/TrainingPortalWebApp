using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TrainingPortal.DAL.Dbo.CourseItems.TestItems.TestQuestionItems;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.SqlDAL.Repositories
{
    public class AnswersDboInnerRepository : IDboInnerRepository<AnswerDbo>
    {
        public List<AnswerDbo> Items { get; set; }

        private const string CreateStoredProcedureName = "[dbo].[CreateAnswer]";
        private const string ReadStoredProcedureName = "[dbo].[GetAnswerById]";
        private const string ReadAllByParentIdStoredProcedureName = "[dbo].[GetAnswersByQuestionId]";
        private const string ReadAllQuery = "SELECT* FROM[dbo].[Answers]";
        private const string UpdateStoredProcedureName = "[dbo].[UpdateAnswerById]";
        private const string DeleteStoredProcedureName = "[dbo].[DeleteAnswerById]";
        private const string DeleteAllByParentIdStoredProcedureName = "[dbo].[DeleteAnswersByQuestionId]";

        private readonly IDbCommandPerformer dBService;

        public AnswersDboInnerRepository(IDbCommandPerformer dBService)
        {
            Items = new List<AnswerDbo>();
            this.dBService = dBService;
        }

        public int Create(AnswerDbo dataInstance)
        {
            var storedProcedureName = CreateStoredProcedureName;
            var parameters = new List<SqlParameter>()
            {
                new("QuestionId", DbType.Int32) { Value = dataInstance.QuestionId },
                new("Text", DbType.String) { Value = dataInstance.Text },
                new("IsRightAnswer", DbType.Boolean) { Value = dataInstance.IsRightAnswer }
            };

            return dBService.PerformScalar(storedProcedureName, parameters);
        }

        public AnswerDbo Read(int id)
        {
            var storedProcedureName = ReadStoredProcedureName;
            var parameters = new List<SqlParameter>()
            {
                new("Id", DbType.Int32) { Value = id }
            };
            Items = dBService.PerformStoredProcedure<AnswerDbo>(storedProcedureName, parameters);

            return Items[0];
        }

        public List<AnswerDbo> ReadAllByParentId(int id)
        {
            var storedProcedureName = ReadAllByParentIdStoredProcedureName;
            var parameters = new List<SqlParameter>()
            {
                new("QuestionId", DbType.Int32) { Value = id }
            };
            Items = dBService.PerformStoredProcedure<AnswerDbo>(storedProcedureName, parameters);

            return Items;
        }

        public List<AnswerDbo> ReadAll()
        {
            var query = ReadAllQuery;
            Items = dBService.PerformQuery<AnswerDbo>(query, new List<SqlParameter>());

            return Items;
        }

        public int Update(int id, AnswerDbo dataInstance)
        {
            var storedProcedureName = UpdateStoredProcedureName;
            var parameters = new List<SqlParameter>()
            {
                new("Id", DbType.Int32) { Value = id },
                new("QuestionId", DbType.Int32) { Value = dataInstance.QuestionId },
                new("Text", DbType.String) { Value = dataInstance.Text },
                new("IsRightAnswer", DbType.Boolean) { Value = dataInstance.IsRightAnswer }
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
                new("QuestionId", DbType.Int32) { Value = id }
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