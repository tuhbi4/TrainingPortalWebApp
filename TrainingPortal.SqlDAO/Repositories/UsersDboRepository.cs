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

        private readonly IDbCommandPerformer _dBService;

        public UsersDboRepository(IDbCommandPerformer dBService)
        {
            Items = new List<UserDbo>();
            _dBService = dBService;
        }

        public int Create(UserDbo dataInstance)
        {
            var storedProcedureName = "[dbo].[CreateUser]";
            var parameters = new List<SqlParameter>()
            {
                new("Login", DbType.String) { Value = dataInstance.Login },
                new("PasswordHash", DbType.String) { Value = dataInstance.Password},
                new("Email", DbType.String) { Value = dataInstance.Email },
                new("RoleId", DbType.Int32) { Value = dataInstance.RoleId },
                new("Lastname", DbType.String) { Value = dataInstance.Lastname},
                new("Firstname", DbType.String) { Value = dataInstance.Firstname },
                new("Patronymic", DbType.String) { Value = dataInstance.Patronymic }
            };

            return _dBService.PerformNonQuery(storedProcedureName, parameters);
        }

        public UserDbo Read(int id)
        {
            var storedProcedureName = "[dbo].[GetUserById]";
            var parameters = new List<SqlParameter>()
            {
                new("Id", DbType.Int32) { Value = id }
            };
            Items = _dBService.PerformStoredProcedure<UserDbo>(storedProcedureName, parameters);

            return Items[0];
        }

        public List<UserDbo> ReadAll()
        {
            var query = $"SELECT * FROM [dbo].[Users]";
            Items = _dBService.PerformQuery<UserDbo>(query, new List<SqlParameter>());

            return Items;
        }

        public int Update(int id, UserDbo dataInstance)
        {
            var storedProcedureName = "[dbo].[UpdateUserById]";
            var parameters = new List<SqlParameter>()
            {
                new("Id", DbType.Int32) { Value = id },
                new("Login", DbType.String) { Value = dataInstance.Login },
                new("PasswordHash", DbType.String) { Value = dataInstance.Password},
                new("Email", DbType.String) { Value = dataInstance.Email },
                new("RoleId", DbType.Int32) { Value = dataInstance.RoleId },
                new("Lastname", DbType.String) { Value = dataInstance.Lastname},
                new("Firstname", DbType.String) { Value = dataInstance.Firstname },
                new("Patronymic", DbType.String) { Value = dataInstance.Patronymic }
            };

            return _dBService.PerformNonQuery(storedProcedureName, parameters);
        }

        public int Delete(int id)
        {
            var storedProcedureName = "[dbo].[DeleteUserById]";
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