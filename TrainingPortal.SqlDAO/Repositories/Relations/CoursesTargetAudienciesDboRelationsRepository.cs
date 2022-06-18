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

        private const string CreateStoredProcedureName = "[dbo].[CreateCoursesTargetAudiencies]";
        private const string ReadStoredProcedureName = "[dbo].[GetCoursesTargetAudienciesByCourseId]";
        private const string ReadAllQuery = "SELECT* FROM[dbo].[Courses_TargetAudiencies]";
        private const string UpdateStoredProcedureName = "[dbo].[UpdateCoursesTargetAudienciesByCourseId]";
        private const string DeleteStoredProcedureName = "[dbo].[DeleteCoursesTargetAudienciesByCourseId]";
        private const string DeleteByIdStoredProcedureName = "[dbo].[DeleteCoursesTargetAudienciesByCourseIdAndTargetAudienceId]";

        private readonly IDbCommandPerformer dBService;

        public CoursesTargetAudienciesDboRelationsRepository(IDbCommandPerformer dBService)
        {
            Items = new List<CoursesTargetAudienciesDboRelation>();
            this.dBService = dBService;
        }

        public int Create(CoursesTargetAudienciesDboRelation dataInstance)
        {
            var storedProcedureName = CreateStoredProcedureName;
            var parameters = new List<SqlParameter>()
            {
                new("CourseId", DbType.Int32) { Value = dataInstance.CourseId },
                new("TargetAudienceId", DbType.Int32) { Value = dataInstance.TargetAudienceId }
            };

            return dBService.PerformScalar(storedProcedureName, parameters);
        }

        CoursesTargetAudienciesDboRelation IDboRepository<CoursesTargetAudienciesDboRelation>.Read(int id)
        {
            return Read(id)[0];
        }

        public List<CoursesTargetAudienciesDboRelation> Read(int id)
        {
            var storedProcedureName = ReadStoredProcedureName;
            var parameters = new List<SqlParameter>()
            {
                new("CourseId", DbType.Int32) { Value = id }
            };
            Items = dBService.PerformStoredProcedure<CoursesTargetAudienciesDboRelation>(storedProcedureName, parameters);

            return Items;
        }

        public List<CoursesTargetAudienciesDboRelation> ReadAll()
        {
            var query = ReadAllQuery;
            Items = dBService.PerformQuery<CoursesTargetAudienciesDboRelation>(query, new List<SqlParameter>());

            return Items;
        }

        public int Update(int id, CoursesTargetAudienciesDboRelation dataInstance)
        {
            var storedProcedureName = UpdateStoredProcedureName;
            var parameters = new List<SqlParameter>()
            {
                new("CourseId", DbType.Int32) { Value = dataInstance.CourseId },
                new("TargetAudienceId", DbType.Int32) { Value = dataInstance.TargetAudienceId }
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

        public int Delete(CoursesTargetAudienciesDboRelation dataInstance)
        {
            var storedProcedureName = DeleteByIdStoredProcedureName;
            var parameters = new List<SqlParameter>()
            {
                new("CourseId", DbType.Int32) { Value = dataInstance.CourseId },
                new("TargetAudienceId", DbType.Int32) { Value = dataInstance.TargetAudienceId }
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