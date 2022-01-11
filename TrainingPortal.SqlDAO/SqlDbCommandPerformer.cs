using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TrainingPortal.DAL.Interfaces;
using TrainingPortal.Entities;

namespace TrainingPortal.SqlDAL
{
    public class SqlDbCommandPerformer : IDbCommandPerformer
    {
        private readonly IDboModelMapper mapper;
        private readonly ConnectionSettings connectionStringProvider;
        private SqlConnection connection;

        public SqlDbCommandPerformer(ConnectionSettings connectionStringProvider, IDboModelMapper mapper)
        {
            this.connectionStringProvider = connectionStringProvider;
            this.mapper = mapper;
        }

        public List<T> PerformStoredProcedure<T>(string storedProcedureName, List<SqlParameter> parameters) where T : class
        {
            connection = new SqlConnection(connectionStringProvider.ConnectionString);

            List<T> items = null;
            using (connection)
            {
                var command = new SqlCommand(storedProcedureName, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                items = GetModels<T>(parameters, command);
            }

            return items;
        }

        public List<T> PerformQuery<T>(string query, List<SqlParameter> parameters) where T : class
        {
            connection = new SqlConnection(connectionStringProvider.ConnectionString);

            List<T> items = null;
            using (connection)
            {
                var command = new SqlCommand(query, connection);
                items = GetModels<T>(parameters, command);
            }

            return items;
        }

        public int PerformNonQuery(string storedProcedureName, List<SqlParameter> parameters)
        {
            connection = new SqlConnection(connectionStringProvider.ConnectionString);

            int result = 0;
            using (connection)
            {
                var command = new SqlCommand(storedProcedureName, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                foreach (var parameter in parameters)
                {
                    command.Parameters.AddWithValue(parameter.ParameterName, parameter.Value ?? DBNull.Value);
                }

                connection.Open();
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

            connection.Open();

            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        items.Add(mapper.CreateInstance<T>(reader));
                    }
                }
            }

            return items;
        }
    }
}