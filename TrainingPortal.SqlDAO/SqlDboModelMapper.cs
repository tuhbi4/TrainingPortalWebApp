using System;
using System.Data.SqlClient;
using TrainingPortal.DAL.Dbo.CourseItems;
using TrainingPortal.DAL.Dbo.CourseItems.TestItems;
using TrainingPortal.DAL.Dbo.CourseItems.TestItems.TestQuestionItems;
using TrainingPortal.DAL.Dbo.Models;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.SqlDAL
{
    public class SqlDboModelMapper : IDboModelMapper
    {
        public T CreateInstance<T>(SqlDataReader reader) where T : class
        {
            return typeof(T).Name switch
            {
                nameof(AnswerDbo) => new AnswerDbo((int)reader.GetValue(0), (int)reader.GetValue(1), reader.GetValue(2).ToString()) as T,
                nameof(CategoryDbo) => new CategoryDbo((int)reader.GetValue(0), reader.GetValue(1).ToString()) as T,
                nameof(CertificateDbo) => new CertificateDbo((int)reader.GetValue(0), reader.GetValue(1).ToString(), reader.GetValue(2).ToString()) as T,
                nameof(CourseDbo) => new CourseDbo((int)reader.GetValue(0), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), (int)reader.GetValue(3),
                    (int)reader.GetValue(4), (int)reader.GetValue(5)) as T,
                nameof(CoursesLessonsDboRelation) => new CoursesLessonsDboRelation((int)reader.GetValue(0), (int)reader.GetValue(1)) as T,
                nameof(CoursesTargetAudienciesDboRelation) => new CoursesTargetAudienciesDboRelation((int)reader.GetValue(0), (int)reader.GetValue(1)) as T,
                nameof(LessonDbo) => new LessonDbo((int)reader.GetValue(0), reader.GetValue(1).ToString(), reader.GetValue(2).ToString()) as T,
                nameof(TestQuestionDbo) => new TestQuestionDbo((int)reader.GetValue(0), (int)reader.GetValue(1), reader.GetValue(2).ToString()) as T,
                nameof(RoleDbo) => new RoleDbo((int)reader.GetValue(0), reader.GetValue(1).ToString()) as T,
                nameof(TargetAudienceDbo) => new TargetAudienceDbo((int)reader.GetValue(0), reader.GetValue(1).ToString()) as T,
                nameof(TestDbo) => new TestDbo((int)reader.GetValue(0), reader.GetValue(1).ToString()) as T,
                nameof(UserDbo) => new UserDbo((int)reader.GetValue(0), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(),
                    (int)reader.GetValue(4), reader.GetValue(5).ToString(), reader.GetValue(6).ToString(), reader.GetValue(7).ToString()) as T,
                _ => throw new ArgumentException("The argument type is not in the allowed list.", typeof(T).Name), // TODO: replace throwing exception
            };
        }
    }
}