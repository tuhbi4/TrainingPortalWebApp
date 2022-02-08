using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TrainingPortal.DAL.Dbo.CourseItems;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.SqlDAL.Repositories
{
    public class CertificatesDboRepository : IDboRepository<CertificateDbo>
    {
        public List<CertificateDbo> Items { get; set; }

        private const string CreateStoredProcedureName = "[dbo].[CreateCertificate]";
        private const string ReadStoredProcedureName = "[dbo].[GetCertificateById]";
        private const string ReadAllQuery = "SELECT* FROM[dbo].[Certificates]";
        private const string UpdateStoredProcedureName = "[dbo].[UpdateCertificateById]";
        private const string DeleteStoredProcedureName = "[dbo].[DeleteCertificateById]";

        private readonly IDbCommandPerformer dBService;

        public CertificatesDboRepository(IDbCommandPerformer dBService)
        {
            Items = new List<CertificateDbo>();
            this.dBService = dBService;
        }

        public int Create(CertificateDbo dataInstance)
        {
            var storedProcedureName = CreateStoredProcedureName;
            var parameters = new List<SqlParameter>()
            {
                new("@CourseName", DbType.String) { Value = dataInstance.CourseName },
                new("@ImageLink", DbType.String) { Value = dataInstance.ImageLink }
            };

            return dBService.PerformScalar(storedProcedureName, parameters);
        }

        public CertificateDbo Read(int id)
        {
            var storedProcedureName = ReadStoredProcedureName;
            var parameters = new List<SqlParameter>()
            {
                new("Id", DbType.Int32) { Value = id }
            };
            Items = dBService.PerformStoredProcedure<CertificateDbo>(storedProcedureName, parameters);

            return Items[0];
        }

        public List<CertificateDbo> ReadAll()
        {
            var query = ReadAllQuery;
            Items = dBService.PerformQuery<CertificateDbo>(query, new List<SqlParameter>());

            return Items;
        }

        public int Update(int id, CertificateDbo dataInstance)
        {
            var storedProcedureName = UpdateStoredProcedureName;
            var parameters = new List<SqlParameter>()
            {
                new("Id", DbType.Int32) { Value = id },
                new("@CourseName", DbType.String) { Value = dataInstance.CourseName },
                new("@ImageLink", DbType.String) { Value = dataInstance.ImageLink }
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