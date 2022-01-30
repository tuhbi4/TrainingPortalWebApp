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

        private readonly IDbCommandPerformer _dBService;

        public AnswersDboInnerRepository(IDbCommandPerformer dBService)
        {
            Items = new List<AnswerDbo>();
            _dBService = dBService;
        }

        public int Create(AnswerDbo dataInstance)
        {
            var storedProcedureName = "[dbo].[CreateAnswer]";
            var parameters = new List<SqlParameter>()
            {
                new("QuestionId", DbType.Int32) { Value = dataInstance.QuestionId },
                new("Answer", DbType.String) { Value = dataInstance.Text },
                new("IsRightAnswer", DbType.Boolean) { Value = dataInstance.IsRightAnswer }
            };

            return _dBService.PerformScalar(storedProcedureName, parameters);
        }

        public AnswerDbo Read(int id)
        {
            var storedProcedureName = "[dbo].[GetAnswerById]";
            var parameters = new List<SqlParameter>()
            {
                new("Id", DbType.Int32) { Value = id }
            };
            Items = _dBService.PerformStoredProcedure<AnswerDbo>(storedProcedureName, parameters);

            return Items[0];
        }

        public List<AnswerDbo> ReadAllByParentId(int id)
        {
            var storedProcedureName = "[dbo].[GetAnswersByQuestionId]";
            var parameters = new List<SqlParameter>()
            {
                new("QuestionId", DbType.Int32) { Value = id }
            };
            Items = _dBService.PerformStoredProcedure<AnswerDbo>(storedProcedureName, parameters);

            return Items;
        }

        public List<AnswerDbo> ReadAll()
        {
            var query = $"SELECT * FROM [dbo].[Answers]";
            Items = _dBService.PerformQuery<AnswerDbo>(query, new List<SqlParameter>());

            return Items;
        }

        public int Update(int id, AnswerDbo dataInstance)
        {
            var storedProcedureName = "[dbo].[UpdateAnswerById]";
            var parameters = new List<SqlParameter>()
            {
                new("Id", DbType.Int32) { Value = id },
                new("QuestionId", DbType.Int32) { Value = dataInstance.QuestionId },
                new("Answer", DbType.String) { Value = dataInstance.Text },
                new("IsRightAnswer", DbType.Boolean) { Value = dataInstance.IsRightAnswer }
            };

            return _dBService.PerformScalar(storedProcedureName, parameters);
        }

        public int Delete(int id)
        {
            var storedProcedureName = "[dbo].[DeleteAnswerById]";
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
            var storedProcedureName = "[dbo].[DeleteAnswersByQuestionId]";
            var parameters = new List<SqlParameter>()
            {
                new("QuestionId", DbType.Int32) { Value = id }
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