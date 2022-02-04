using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TrainingPortal.DAL.Dbo.Models;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.SqlDAL.Repositories
{
    public class CoursesDboRepository : IDboRepository<CourseDbo>, ISearchableDboRepository<CourseDbo>
    {
        public List<CourseDbo> Items { get; set; }

        private readonly IDbCommandPerformer _dBService;

        public CoursesDboRepository(IDbCommandPerformer dBService)
        {
            Items = new List<CourseDbo>();
            _dBService = dBService;
        }

        public int Create(CourseDbo dataInstance)
        {
            var storedProcedureName = "[dbo].[CreateCourse]";
            var parameters = new List<SqlParameter>()
            {
                new("Name", DbType.String) { Value = dataInstance.Name },
                new("Description", DbType.String) { Value = dataInstance.Description },
                new("CategoryId", DbType.Int32) { Value = dataInstance.CategoryId },
                new("TestId", DbType.Int32) { Value = dataInstance.TestId },
                new("CertificateId", DbType.Int32) { Value = dataInstance.CertificateId }
            };

            return _dBService.PerformScalar(storedProcedureName, parameters);
        }

        public CourseDbo Read(int id)
        {
            var storedProcedureName = "[dbo].[GetCourseById]";
            var parameters = new List<SqlParameter>()
            {
                new("Id", DbType.Int32) { Value = id }
            };
            Items = _dBService.PerformStoredProcedure<CourseDbo>(storedProcedureName, parameters);

            return Items[0];
        }

        public List<CourseDbo> ReadAll()
        {
            var query = $"SELECT * FROM [dbo].[Courses]";
            Items = _dBService.PerformQuery<CourseDbo>(query, new List<SqlParameter>());

            return Items;
        }

        public int Update(int id, CourseDbo dataInstance)
        {
            var storedProcedureName = "[dbo].[UpdateCourseById]";
            var parameters = new List<SqlParameter>()
            {
                new("Id", DbType.Int32) { Value = id },
                new("Name", DbType.String) { Value = dataInstance.Name },
                new("Description", DbType.String) { Value = dataInstance.Description },
                new("CategoryId", DbType.Int32) { Value = dataInstance.CategoryId },
                new("TestId", DbType.Int32) { Value = dataInstance.TestId },
                new("CertificateId", DbType.Int32) { Value = dataInstance.CertificateId }
            };

            return _dBService.PerformScalar(storedProcedureName, parameters);
        }

        public int Delete(int id)
        {
            var storedProcedureName = "[dbo].[DeleteCourseWithChildsById]";
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

        public List<CourseDbo> Search(string courseName, string categoryName, string targetAudiencyName)
        {
            var storedProcedureName = "[dbo].[SearchCourse]";
            var parameters = new List<SqlParameter>()
            {
                new("Course", DbType.String) { Value = courseName },
                new("Category", DbType.String) { Value = categoryName },
                new("TargetAudience", DbType.String) { Value = targetAudiencyName }
            };
            Items = _dBService.PerformStoredProcedure<CourseDbo>(storedProcedureName, parameters);

            return Items;
        }
    }
}