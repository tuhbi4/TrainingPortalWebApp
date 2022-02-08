using System;
using System.Data.SqlClient;
using System.Reflection;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.SqlDAL
{
    public class SqlDboModelMapper : IDboModelMapper
    {
        public T CreateInstance<T>(SqlDataReader reader) where T : class, new()
        {
            T result = new();
            int fieldCount = reader.FieldCount;

            for (int i = 0; i < fieldCount; i++)
            {
                Type fieldType = reader.GetFieldType(i);
                string fieldName = reader.GetName(i);
                object fieldValue = reader.GetValue(i);

                if (fieldValue is DBNull)
                {
                    fieldValue = null;
                }
                PropertyInfo propertyName = typeof(T).GetProperty(fieldName);

                switch (fieldType.Name)
                {
                    case nameof(Int32):
                        propertyName.SetValue(result, (int)fieldValue);
                        break;

                    case nameof(String):
                        propertyName.SetValue(result, (string)fieldValue ?? null);
                        break;

                    case nameof(Boolean):
                        propertyName.SetValue(result, (bool)fieldValue);
                        break;

                    default: throw new ArgumentException("Argument type not registered", fieldType.Name);
                }
            }

            return result;
        }
    }
}