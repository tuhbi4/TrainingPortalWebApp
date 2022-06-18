using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TrainingPortal.DAL.Dbo.CourseItems;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.SqlDAL.Repositories
{
    public class CoursesLessonsDboRelationsRepository : IDboRelationsRepository<CoursesLessonsDboRelation>
    {
        public List<CoursesLessonsDboRelation> Items { get; set; }

        private const string CreateStoredProcedureName = "[dbo].[CreateCoursesLessons]";
        private const string ReadStoredProcedureName = "[dbo].[GetCoursesLessonsByCourseId]";
        private const string ReadAllQuery = "SELECT* FROM[dbo].[Courses_Lessons]";
        private const string UpdateStoredProcedureName = "[dbo].[UpdateCoursesLessonsByCourseId]";
        private const string DeleteStoredProcedureName = "[dbo].[DeleteCoursesLessonsByCourseId]";
        private const string DeleteByIdStoredProcedureName = "[dbo].[DeleteCoursesLessonsByCourseIdAndLessonId]";

        private readonly IDbCommandPerformer dBService;

        public CoursesLessonsDboRelationsRepository(IDbCommandPerformer dBService)
        {
            Items = new List<CoursesLessonsDboRelation>();
            this.dBService = dBService;
        }

        public int Create(CoursesLessonsDboRelation dataInstance)
        {
            var storedProcedureName = CreateStoredProcedureName;
            var parameters = new List<SqlParameter>()
            {
                new("CourseId", DbType.Int32) { Value = dataInstance.CourseId },
                new("LessonId", DbType.Int32) { Value = dataInstance.LessonId }
            };

            return dBService.PerformScalar(storedProcedureName, parameters);
        }

        CoursesLessonsDboRelation IDboRepository<CoursesLessonsDboRelation>.Read(int id)
        {
            return Read(id)[0];
        }

        public List<CoursesLessonsDboRelation> Read(int id)
        {
            var storedProcedureName = ReadStoredProcedureName;
            var parameters = new List<SqlParameter>()
            {
                new("CourseId", DbType.Int32) { Value = id }
            };
            Items = dBService.PerformStoredProcedure<CoursesLessonsDboRelation>(storedProcedureName, parameters);

            return Items;
        }

        public List<CoursesLessonsDboRelation> ReadAll()
        {
            var query = ReadAllQuery;
            Items = dBService.PerformQuery<CoursesLessonsDboRelation>(query, new List<SqlParameter>());

            return Items;
        }

        public int Update(int id, CoursesLessonsDboRelation dataInstance)
        {
            var storedProcedureName = UpdateStoredProcedureName;
            var parameters = new List<SqlParameter>()
            {
                new("CourseId", DbType.Int32) { Value = dataInstance.CourseId },
                new("LessonId", DbType.Int32) { Value = dataInstance.LessonId }
            };

            return dBService.PerformScalar(storedProcedureName, parameters);
        }

        public int Delete(int id)
        {
            var storedProcedureName = DeleteStoredProcedureName;
            var parameters = new List<SqlParameter>()
            {
                new("CourseId", DbType.Int32) { Value = id }
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

        public int Delete(CoursesLessonsDboRelation dataInstance)
        {
            var storedProcedureName = DeleteByIdStoredProcedureName;
            var parameters = new List<SqlParameter>()
            {
                new("CourseId", DbType.Int32) { Value = dataInstance.CourseId },
                new("LessonId", DbType.Int32) { Value = dataInstance.LessonId }
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