using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TrainingPortal.DAL.Dbo.Models;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.SqlDAL.Repositories
{
    public class CategoriesDboRepository : IDboRepository<CategoryDbo>
    {
        public List<CategoryDbo> Items { get; set; }

        private const string CreateStoredProcedureName = "[dbo].[CreateCategory]";
        private const string ReadStoredProcedureName = "[dbo].[GetCategoryById]";
        private const string ReadAllQuery = "SELECT* FROM[dbo].[Categories]";
        private const string UpdateStoredProcedureName = "[dbo].[UpdateCategoryById]";
        private const string DeleteStoredProcedureName = "[dbo].[DeleteCategoryById]";

        private readonly IDbCommandPerformer dBService;

        public CategoriesDboRepository(IDbCommandPerformer dBService)
        {
            Items = new List<CategoryDbo>();
            this.dBService = dBService;
        }

        public int Create(CategoryDbo dataInstance)
        {
            var storedProcedureName = CreateStoredProcedureName;
            var parameters = new List<SqlParameter>()
            {
                new("Name", DbType.String) { Value = dataInstance.Name }
            };

            return dBService.PerformScalar(storedProcedureName, parameters);
        }

        public CategoryDbo Read(int id)
        {
            var storedProcedureName = ReadStoredProcedureName;
            var parameters = new List<SqlParameter>()
            {
                new("Id", DbType.Int32) { Value = id }
            };
            Items = dBService.PerformStoredProcedure<CategoryDbo>(storedProcedureName, parameters);

            return Items[0];
        }

        public List<CategoryDbo> ReadAll()
        {
            var query = ReadAllQuery;
            Items = dBService.PerformQuery<CategoryDbo>(query, new List<SqlParameter>());

            return Items;
        }

        public int Update(int id, CategoryDbo dataInstance)
        {
            var storedProcedureName = UpdateStoredProcedureName;
            var parameters = new List<SqlParameter>()
            {
                new("Id", DbType.Int32) { Value = id },
                new("Name", DbType.String) { Value = dataInstance.Name }
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