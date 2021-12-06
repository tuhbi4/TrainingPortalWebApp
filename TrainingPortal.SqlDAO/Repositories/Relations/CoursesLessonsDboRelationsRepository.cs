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

        private readonly IDbCommandPerformer _dBService;

        public CoursesLessonsDboRelationsRepository(IDbCommandPerformer dBService)
        {
            Items = new List<CoursesLessonsDboRelation>();
            _dBService = dBService;
        }

        public int Create(CoursesLessonsDboRelation dataInstance)
        {
            var storedProcedureName = "[dbo].[CreateCoursesLessons]";
            var parameters = new List<SqlParameter>()
            {
                new("CourseId", DbType.Int32) { Value = dataInstance.CourseId },
                new("LessonId", DbType.Int32) { Value = dataInstance.LessonId }
            };

            return _dBService.PerformNonQuery(storedProcedureName, parameters);
        }

        CoursesLessonsDboRelation IDboRepository<CoursesLessonsDboRelation>.Read(int id)
        {
            return Read(id)[0];
        }

        public List<CoursesLessonsDboRelation> Read(int id)
        {
            var storedProcedureName = "[dbo].[GetCoursesLessonsByCourseId]";
            var parameters = new List<SqlParameter>()
            {
                new("CourseId", DbType.Int32) { Value = id }
            };
            Items = _dBService.PerformStoredProcedure<CoursesLessonsDboRelation>(storedProcedureName, parameters);

            return Items;
        }

        public List<CoursesLessonsDboRelation> ReadAll()
        {
            var query = $"SELECT * FROM [dbo].[Courses_Lessons]";
            Items = _dBService.PerformQuery<CoursesLessonsDboRelation>(query, new List<SqlParameter>());

            return Items;
        }

        public int Update(int id, CoursesLessonsDboRelation dataInstance)
        {
            var storedProcedureName = "[dbo].[UpdateCoursesLessonsByCourseId]";
            var parameters = new List<SqlParameter>()
            {
                new("CourseId", DbType.Int32) { Value = dataInstance.CourseId },
                new("LessonId", DbType.Int32) { Value = dataInstance.LessonId }
            };

            return _dBService.PerformNonQuery(storedProcedureName, parameters);
        }

        public int Delete(int id)
        {
            var storedProcedureName = "[dbo].[DeleteCoursesLessonsByCourseId]";
            var parameters = new List<SqlParameter>()
            {
                new("CourseId", DbType.Int32) { Value = id }
            };

            try
            {
                return _dBService.PerformNonQuery(storedProcedureName, parameters);
            }
            catch
            {
                return 0;
            }
        }

        public int Delete(CoursesLessonsDboRelation dataInstance)
        {
            var storedProcedureName = "[dbo].[DeleteCoursesLessonsByCourseIdAndLessonId]";
            var parameters = new List<SqlParameter>()
            {
                new("CourseId", DbType.Int32) { Value = dataInstance.CourseId },
                new("LessonId", DbType.Int32) { Value = dataInstance.LessonId }
            };

            try
            {
                return _dBService.PerformNonQuery(storedProcedureName, parameters);
            }
            catch
            {
                return 0;
            }
        }
    }
}