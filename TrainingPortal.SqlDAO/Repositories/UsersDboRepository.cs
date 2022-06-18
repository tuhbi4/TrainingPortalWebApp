using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TrainingPortal.DAL.Dbo.Models;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.SqlDAL.Repositories
{
    public class UsersDboRepository : IDboRepository<UserDbo>
    {
        public List<UserDbo> Items { get; set; }

        private const string CreateStoredProcedureName = "[dbo].[CreateUser]";
        private const string ReadStoredProcedureName = "[dbo].[GetUserById]";
        private const string ReadAllQuery = "SELECT* FROM[dbo].[Users]";
        private const string UpdateStoredProcedureName = "[dbo].[UpdateUserById]";
        private const string DeleteStoredProcedureName = "[dbo].[DeleteUserById]";

        private readonly IDbCommandPerformer dBService;

        public UsersDboRepository(IDbCommandPerformer dBService)
        {
            Items = new List<UserDbo>();
            this.dBService = dBService;
        }

        public UsersDboRepository()
        {
        }

        public int Create(UserDbo dataInstance)
        {
            var storedProcedureName = CreateStoredProcedureName;
            var parameters = new List<SqlParameter>()
            {
                new("Login", DbType.String) { Value = dataInstance.Login },
                new("PasswordHash", DbType.String) { Value = dataInstance.PasswordHash},
                new("Email", DbType.String) { Value = dataInstance.Email },
                new("RoleId", DbType.Int32) { Value = dataInstance.RoleId },
                new("Lastname", DbType.String) { Value = dataInstance.Lastname},
                new("Firstname", DbType.String) { Value = dataInstance.Firstname },
                new("Patronymic", DbType.String) { Value = dataInstance.Patronymic }
            };

            return dBService.PerformScalar(storedProcedureName, parameters);
        }

        public UserDbo Read(int id)
        {
            var storedProcedureName = ReadStoredProcedureName;
            var parameters = new List<SqlParameter>()
            {
                new("Id", DbType.Int32) { Value = id }
            };
            Items = dBService.PerformStoredProcedure<UserDbo>(storedProcedureName, parameters);

            return Items[0];
        }

        public List<UserDbo> ReadAll()
        {
            var query = ReadAllQuery;
            Items = dBService.PerformQuery<UserDbo>(query, new List<SqlParameter>());

            return Items;
        }

        public int Update(int id, UserDbo dataInstance)
        {
            var storedProcedureName = UpdateStoredProcedureName;
            var parameters = new List<SqlParameter>()
            {
                new("Id", DbType.Int32) { Value = id },
                new("Login", DbType.String) { Value = dataInstance.Login },
                new("PasswordHash", DbType.String) { Value = dataInstance.PasswordHash},
                new("Email", DbType.String) { Value = dataInstance.Email },
                new("RoleId", DbType.Int32) { Value = dataInstance.RoleId },
                new("Lastname", DbType.String) { Value = dataInstance.Lastname},
                new("Firstname", DbType.String) { Value = dataInstance.Firstname },
                new("Patronymic", DbType.String) { Value = dataInstance.Patronymic }
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