using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TrainingPortal.DAL.Dbo.CourseItems;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.SqlDAL.Repositories
{
    public class CoursesTargetAudienciesDboRelationsRepository : IDboRelationsRepository<CoursesTargetAudienciesDboRelation>
    {
        public List<CoursesTargetAudienciesDboRelation> Items { get; set; }

        private readonly IDbCommandPerformer _dBService;

        public CoursesTargetAudienciesDboRelationsRepository(IDbCommandPerformer dBService)
        {
            Items = new List<CoursesTargetAudienciesDboRelation>();
            _dBService = dBService;
        }

        public int Create(CoursesTargetAudienciesDboRelation dataInstance)
        {
            var storedProcedureName = "[dbo].[CreateCoursesTargetAudiencies]";
            var parameters = new List<SqlParameter>()
            {
                new("CourseId", DbType.Int32) { Value = dataInstance.CourseId },
                new("TargetAudienceId", DbType.Int32) { Value = dataInstance.TargetAudienceId }
            };

            return _dBService.PerformNonQuery(storedProcedureName, parameters);
        }

        CoursesTargetAudienciesDboRelation IDboRepository<CoursesTargetAudienciesDboRelation>.Read(int id)
        {
            return Read(id)[0];
        }

        public List<CoursesTargetAudienciesDboRelation> Read(int id)
        {
            var storedProcedureName = "[dbo].[GetCoursesTargetAudienciesByCourseId]";
            var parameters = new List<SqlParameter>()
            {
                new("CourseId", DbType.Int32) { Value = id }
            };
            Items = _dBService.PerformStoredProcedure<CoursesTargetAudienciesDboRelation>(storedProcedureName, parameters);

            return Items;
        }

        public List<CoursesTargetAudienciesDboRelation> ReadAll()
        {
            var query = $"SELECT * FROM [dbo].[Courses_TargetAudiencies]";
            Items = _dBService.PerformQuery<CoursesTargetAudienciesDboRelation>(query, new List<SqlParameter>());

            return Items;
        }

        public int Update(int id, CoursesTargetAudienciesDboRelation dataInstance)
        {
            var storedProcedureName = "[dbo].[UpdateCoursesTargetAudienciesByCourseId]";
            var parameters = new List<SqlParameter>()
            {
                new("CourseId", DbType.Int32) { Value = dataInstance.CourseId },
                new("TargetAudienceId", DbType.Int32) { Value = dataInstance.TargetAudienceId }
            };

            return _dBService.PerformNonQuery(storedProcedureName, parameters);
        }

        public int Delete(int id)
        {
            var storedProcedureName = "[dbo].[DeleteCoursesTargetAudienciesByCourseId]";
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

        public int Delete(CoursesTargetAudienciesDboRelation dataInstance)
        {
            var storedProcedureName = "[dbo].[DeleteCoursesTargetAudienciesByCourseIdAndTargetAudienceId]";
            var parameters = new List<SqlParameter>()
            {
                new("CourseId", DbType.Int32) { Value = dataInstance.CourseId },
                new("TargetAudienceId", DbType.Int32) { Value = dataInstance.TargetAudienceId }
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