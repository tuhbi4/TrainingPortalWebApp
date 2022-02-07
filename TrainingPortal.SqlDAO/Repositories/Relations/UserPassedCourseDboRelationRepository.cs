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

        private readonly IDbCommandPerformer _dBService;

        public UserPassedCourseDboRelationRepository(IDbCommandPerformer dBService)
        {
            Items = new List<UserPassedCourseDboRelation>();
            _dBService = dBService;
        }

        public int Create(UserPassedCourseDboRelation dataInstance)
        {
            var storedProcedureName = "[dbo].[CreateUserPassedCourse]";
            var parameters = new List<SqlParameter>()
            {
                new("UserId", DbType.Int32) { Value = dataInstance.UserId },
                new("CourseId", DbType.Int32) { Value = dataInstance.CourseId }
            };

            return _dBService.PerformScalar(storedProcedureName, parameters);
        }

        UserPassedCourseDboRelation IDboRepository<UserPassedCourseDboRelation>.Read(int id)
        {
            return Read(id)[0];
        }

        public List<UserPassedCourseDboRelation> Read(int id)
        {
            var storedProcedureName = "[dbo].[GetUserPassedCoursesByUserId]";
            var parameters = new List<SqlParameter>()
            {
                new("UserId", DbType.Int32) { Value = id }
            };
            Items = _dBService.PerformStoredProcedure<UserPassedCourseDboRelation>(storedProcedureName, parameters);

            return Items;
        }

        public List<UserPassedCourseDboRelation> ReadAll()
        {
            var query = $"SELECT * FROM [dbo].[Users_PassedCourses]";
            Items = _dBService.PerformQuery<UserPassedCourseDboRelation>(query, new List<SqlParameter>());

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