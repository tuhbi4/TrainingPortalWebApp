using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TrainingPortal.DAL.Dbo.CourseItems;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.SqlDAL.Repositories
{
    public class LessonsDboRepository : IDboRepository<LessonDbo>
    {
        public List<LessonDbo> Items { get; set; }

        private readonly IDbCommandPerformer _dBService;

        public LessonsDboRepository(IDbCommandPerformer dBService)
        {
            Items = new List<LessonDbo>();
            _dBService = dBService;
        }

        public int Create(LessonDbo dataInstance)
        {
            var storedProcedureName = "[dbo].[CreateLesson]";
            var parameters = new List<SqlParameter>()
            {
                new("Name", DbType.String) { Value = dataInstance.Name },
                new("Material", DbType.String) { Value = dataInstance.Material }
            };

            return _dBService.PerformScalar(storedProcedureName, parameters);
        }

        public LessonDbo Read(int id)
        {
            var storedProcedureName = "[dbo].[GetLessonById]";
            var parameters = new List<SqlParameter>()
            {
                new("Id", DbType.Int32) { Value = id }
            };
            Items = _dBService.PerformStoredProcedure<LessonDbo>(storedProcedureName, parameters);

            return Items[0];
        }

        public List<LessonDbo> ReadAll()
        {
            var query = $"SELECT * FROM [dbo].[Lessons]";
            Items = _dBService.PerformQuery<LessonDbo>(query, new List<SqlParameter>());

            return Items;
        }

        public int Update(int id, LessonDbo dataInstance)
        {
            var storedProcedureName = "[dbo].[UpdateLessonById]";
            var parameters = new List<SqlParameter>()
            {
                new("Id", DbType.Int32) { Value = id },
                new("Name", DbType.String) { Value = dataInstance.Name },
                new("Material", DbType.String) { Value = dataInstance.Material }
            };

            return _dBService.PerformScalar(storedProcedureName, parameters);
        }

        public int Delete(int id)
        {
            var storedProcedureName = "[dbo].[DeleteLessonById]";
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