using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TrainingPortal.DAL.Dbo.Models;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.SqlDAL.Repositories
{
    public class CoursesDboRepository : ISearchableDboRepository<CourseDbo>
    {
        public List<CourseDbo> Items { get; set; }

        private const string CreateStoredProcedureName = "[dbo].[CreateCourse]";
        private const string ReadStoredProcedureName = "[dbo].[GetCourseById]";
        private const string ReadAllQuery = "SELECT* FROM[dbo].[Courses]";
        private const string UpdateStoredProcedureName = "[dbo].[UpdateCourseById]";
        private const string DeleteStoredProcedureName = "[dbo].[DeleteCourseWithChildsById]";
        private const string SearchStoredProcedureName = "[dbo].[SearchCourse]";

        private readonly IDbCommandPerformer dBService;

        public CoursesDboRepository(IDbCommandPerformer dBService)
        {
            Items = new List<CourseDbo>();
            this.dBService = dBService;
        }

        public int Create(CourseDbo dataInstance)
        {
            var storedProcedureName = CreateStoredProcedureName;
            var parameters = new List<SqlParameter>()
            {
                new("Name", DbType.String) { Value = dataInstance.Name },
                new("Description", DbType.String) { Value = dataInstance.Description },
                new("CategoryId", DbType.Int32) { Value = dataInstance.CategoryId },
                new("TestId", DbType.Int32) { Value = dataInstance.TestId },
                new("CertificateId", DbType.Int32) { Value = dataInstance.CertificateId }
            };

            return dBService.PerformScalar(storedProcedureName, parameters);
        }

        public CourseDbo Read(int id)
        {
            var storedProcedureName = ReadStoredProcedureName;
            var parameters = new List<SqlParameter>()
            {
                new("Id", DbType.Int32) { Value = id }
            };
            Items = dBService.PerformStoredProcedure<CourseDbo>(storedProcedureName, parameters);

            return Items[0];
        }

        public List<CourseDbo> ReadAll()
        {
            var query = ReadAllQuery;
            Items = dBService.PerformQuery<CourseDbo>(query, new List<SqlParameter>());

            return Items;
        }

        public int Update(int id, CourseDbo dataInstance)
        {
            var storedProcedureName = UpdateStoredProcedureName;
            var parameters = new List<SqlParameter>()
            {
                new("Id", DbType.Int32) { Value = id },
                new("Name", DbType.String) { Value = dataInstance.Name },
                new("Description", DbType.String) { Value = dataInstance.Description },
                new("CategoryId", DbType.Int32) { Value = dataInstance.CategoryId },
                new("TestId", DbType.Int32) { Value = dataInstance.TestId },
                new("CertificateId", DbType.Int32) { Value = dataInstance.CertificateId }
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

        public List<CourseDbo> Search(string courseName, string categoryName, string targetAudiencyName)
        {
            var storedProcedureName = SearchStoredProcedureName;
            var parameters = new List<SqlParameter>()
            {
                new("Course", DbType.String) { Value = courseName },
                new("Category", DbType.String) { Value = categoryName },
                new("TargetAudience", DbType.String) { Value = targetAudiencyName }
            };
            Items = dBService.PerformStoredProcedure<CourseDbo>(storedProcedureName, parameters);

            return Items;
        }
    }
}