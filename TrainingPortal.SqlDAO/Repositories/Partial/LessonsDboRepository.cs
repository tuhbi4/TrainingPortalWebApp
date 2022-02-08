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

        private const string CreateStoredProcedureName = "[dbo].[CreateLesson]";
        private const string ReadStoredProcedureName = "[dbo].[GetLessonById]";
        private const string ReadAllQuery = "SELECT* FROM[dbo].[Lessons]";
        private const string UpdateStoredProcedureName = "[dbo].[UpdateLessonById]";
        private const string DeleteStoredProcedureName = "[dbo].[DeleteLessonById]";

        private readonly IDbCommandPerformer dBService;

        public LessonsDboRepository(IDbCommandPerformer dBService)
        {
            Items = new List<LessonDbo>();
            this.dBService = dBService;
        }

        public int Create(LessonDbo dataInstance)
        {
            var storedProcedureName = CreateStoredProcedureName;
            var parameters = new List<SqlParameter>()
            {
                new("Name", DbType.String) { Value = dataInstance.Name },
                new("Material", DbType.String) { Value = dataInstance.Material }
            };

            return dBService.PerformScalar(storedProcedureName, parameters);
        }

        public LessonDbo Read(int id)
        {
            var storedProcedureName = ReadStoredProcedureName;
            var parameters = new List<SqlParameter>()
            {
                new("Id", DbType.Int32) { Value = id }
            };
            Items = dBService.PerformStoredProcedure<LessonDbo>(storedProcedureName, parameters);

            return Items[0];
        }

        public List<LessonDbo> ReadAll()
        {
            var query = ReadAllQuery;
            Items = dBService.PerformQuery<LessonDbo>(query, new List<SqlParameter>());

            return Items;
        }

        public int Update(int id, LessonDbo dataInstance)
        {
            var storedProcedureName = UpdateStoredProcedureName;
            var parameters = new List<SqlParameter>()
            {
                new("Id", DbType.Int32) { Value = id },
                new("Name", DbType.String) { Value = dataInstance.Name },
                new("Material", DbType.String) { Value = dataInstance.Material }
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