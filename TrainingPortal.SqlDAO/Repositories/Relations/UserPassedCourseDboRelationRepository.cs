using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TrainingPortal.DAL.Dbo.Models;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.SqlDAL.Repositories
{
    public class UserPassedCourseDboRelationRepository : IDboRelationsRepository<UserPassedCourseDboRelation>
    {
        public List<UserPassedCourseDboRelation> Items { get; set; }

        private const string CreateStoredProcedureName = "[dbo].[CreateUserPassedCourse]";
        private const string ReadStoredProcedureName = "[dbo].[GetUserPassedCoursesByUserId]";
        private const string ReadAllQuery = "SELECT* FROM[dbo].[Users_PassedCourses]";

        private readonly IDbCommandPerformer dBService;

        public UserPassedCourseDboRelationRepository(IDbCommandPerformer dBService)
        {
            Items = new List<UserPassedCourseDboRelation>();
            this.dBService = dBService;
        }

        public int Create(UserPassedCourseDboRelation dataInstance)
        {
            var storedProcedureName = CreateStoredProcedureName;
            var parameters = new List<SqlParameter>()
            {
                new("UserId", DbType.Int32) { Value = dataInstance.UserId },
                new("CourseId", DbType.Int32) { Value = dataInstance.CourseId }
            };

            return dBService.PerformScalar(storedProcedureName, parameters);
        }

        UserPassedCourseDboRelation IDboRepository<UserPassedCourseDboRelation>.Read(int id)
        {
            return Read(id)[0];
        }

        public List<UserPassedCourseDboRelation> Read(int id)
        {
            var storedProcedureName = ReadStoredProcedureName;
            var parameters = new List<SqlParameter>()
            {
                new("UserId", DbType.Int32) { Value = id }
            };
            Items = dBService.PerformStoredProcedure<UserPassedCourseDboRelation>(storedProcedureName, parameters);

            return Items;
        }

        public List<UserPassedCourseDboRelation> ReadAll()
        {
            var query = ReadAllQuery;
            Items = dBService.PerformQuery<UserPassedCourseDboRelation>(query, new List<SqlParameter>());

            return Items;
        }

        public int Update(int id, UserPassedCourseDboRelation dataInstance)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int Delete(UserPassedCourseDboRelation dataInstance)
        {
            throw new NotImplementedException();
        }
    }
}