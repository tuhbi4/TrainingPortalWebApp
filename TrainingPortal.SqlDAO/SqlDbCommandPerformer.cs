using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TrainingPortal.DAL.Interfaces;
using TrainingPortal.Entities;

namespace TrainingPortal.SqlDAL
{
    public class SqlDbCommandPerformer : IDbCommandPerformer
    {
        private readonly IDboModelMapper _modelMapper;
        private readonly ConnectionSettings _connectionStringProvider;
        private SqlConnection _connection;

        public SqlDbCommandPerformer(ConnectionSettings connectionStringProvider, IDboModelMapper modelMapper)
        {
            _connectionStringProvider = connectionStringProvider;
            _modelMapper = modelMapper;
        }

        public List<T> PerformStoredProcedure<T>(string storedProcedureName, List<SqlParameter> parameters) where T : class
        {
            _connection = new SqlConnection(_connectionStringProvider.ConnectionString);

            List<T> items = null;
            using (_connection)
            {
                var command = new SqlCommand(storedProcedureName, _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                items = GetModels<T>(parameters, command);
            }

            return items;
        }

        public List<T> PerformQuery<T>(string query, List<SqlParameter> parameters) where T : class
        {
            _connection = new SqlConnection(_connectionStringProvider.ConnectionString);

            List<T> items = null;
            using (_connection)
            {
                var command = new SqlCommand(query, _connection);
                items = GetModels<T>(parameters, command);
            }

            return items;
        }

        public int PerformNonQuery(string storedProcedureName, List<SqlParameter> parameters)
        {
            _connection = new SqlConnection(_connectionStringProvider.ConnectionString);

            int result = 0;
            using (_connection)
            {
                var command = new SqlCommand(storedProcedureName, _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }

                _connection.Open();
                result = command.ExecuteNonQuery();
            }

            return result;
        }

        private List<T> GetModels<T>(List<SqlParameter> parameters, SqlCommand command) where T : class
        {
            List<T> items = new();

            foreach (var parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }

            _connection.Open();

            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        items.Add(_modelMapper.CreateInstance<T>(reader));
                    }
                }
            }

            return items;
        }
    }
}