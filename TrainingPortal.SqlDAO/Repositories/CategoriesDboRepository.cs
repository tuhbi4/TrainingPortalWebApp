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

        private readonly IDbCommandPerformer _dBService;

        public CategoriesDboRepository(IDbCommandPerformer dBService)
        {
            Items = new List<CategoryDbo>();
            _dBService = dBService;
        }

        public int Create(CategoryDbo dataInstance)
        {
            var storedProcedureName = "[dbo].[CreateCategory]";
            var parameters = new List<SqlParameter>()
            {
                new("Name", DbType.String) { Value = dataInstance.Name }
            };

            return _dBService.PerformNonQuery(storedProcedureName, parameters);
        }

        public CategoryDbo Read(int id)
        {
            var storedProcedureName = "[dbo].[GetCategoryById]";
            var parameters = new List<SqlParameter>()
            {
                new("Id", DbType.Int32) { Value = id }
            };
            Items = _dBService.PerformStoredProcedure<CategoryDbo>(storedProcedureName, parameters);

            return Items[0];
        }

        public List<CategoryDbo> ReadAll()
        {
            var query = $"SELECT * FROM [dbo].[Categories]";
            Items = _dBService.PerformQuery<CategoryDbo>(query, new List<SqlParameter>());

            return Items;
        }

        public int Update(int id, CategoryDbo dataInstance)
        {
            var storedProcedureName = "[dbo].[UpdateCategoryById]";
            var parameters = new List<SqlParameter>()
            {
                new("Id", DbType.Int32) { Value = id },
                new("Name", DbType.String) { Value = dataInstance.Name }
            };

            return _dBService.PerformNonQuery(storedProcedureName, parameters);
        }

        public int Delete(int id)
        {
            var storedProcedureName = "[dbo].[DeleteCategoryById]";
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