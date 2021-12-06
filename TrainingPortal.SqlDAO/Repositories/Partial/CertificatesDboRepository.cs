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

        private readonly IDbCommandPerformer _dBService;

        public CertificatesDboRepository(IDbCommandPerformer dBService)
        {
            Items = new List<CertificateDbo>();
            _dBService = dBService;
        }

        public int Create(CertificateDbo dataInstance)
        {
            var storedProcedureName = "[dbo].[CreateCertificate]";
            var parameters = new List<SqlParameter>()
            {
                new("@CourseName", DbType.String) { Value = dataInstance.CourseName },
                new("@ImageLink", DbType.String) { Value = dataInstance.ImageLink }
            };

            return _dBService.PerformNonQuery(storedProcedureName, parameters);
        }

        public CertificateDbo Read(int id)
        {
            var storedProcedureName = "[dbo].[GetCertificateById]";
            var parameters = new List<SqlParameter>()
            {
                new("Id", DbType.Int32) { Value = id }
            };
            Items = _dBService.PerformStoredProcedure<CertificateDbo>(storedProcedureName, parameters);

            return Items[0];
        }

        public List<CertificateDbo> ReadAll()
        {
            var query = $"SELECT * FROM [dbo].[Certificates]";
            Items = _dBService.PerformQuery<CertificateDbo>(query, new List<SqlParameter>());

            return Items;
        }

        public int Update(int id, CertificateDbo dataInstance)
        {
            var storedProcedureName = "[dbo].[UpdateCertificateById]";
            var parameters = new List<SqlParameter>()
            {
                new("Id", DbType.Int32) { Value = id },
                new("@CourseName", DbType.String) { Value = dataInstance.CourseName },
                new("@ImageLink", DbType.String) { Value = dataInstance.ImageLink }
            };

            return _dBService.PerformNonQuery(storedProcedureName, parameters);
        }

        public int Delete(int id)
        {
            var storedProcedureName = "[dbo].[DeleteCertificateById]";
            var parameters = new List<SqlParameter>()
            {
                new("Id", DbType.Int32) { Value = id }
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