using AutoMapper;
using System;
using System.Collections.Generic;
using TrainingPortal.BLL.Interfaces;
using TrainingPortal.BLL.Models;
using TrainingPortal.DAL.Dbo.Models;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.BLL.Services.Repositories
{
    public class UserPassedCourseService : IRepositoryService<UserPassedCourse>
    {
        private readonly IMapper mapper;
        private readonly IDboRepository<CourseDbo> courseDboRepository;
        private readonly IDboRelationsRepository<UserPassedCourseDboRelation> userPassedCourseDboRelationsRepository;

        public UserPassedCourseService(IMapper mapper, IDboRepository<CourseDbo> courseDboRepository, IDboRelationsRepository<UserPassedCourseDboRelation> userPassedCourseDboRelationsRepository)
        {
            this.mapper = mapper;
            this.courseDboRepository = courseDboRepository;
            this.userPassedCourseDboRelationsRepository = userPassedCourseDboRelationsRepository;
        }

        public int Create(UserPassedCourse dataInstance)
        {
            UserPassedCourseDboRelation mappedInstance = mapper.Map<UserPassedCourseDboRelation>(dataInstance);
            return userPassedCourseDboRelationsRepository.Create(mappedInstance);
        }

        public UserPassedCourse Read(int id)
        {
            throw new NotImplementedException();
        }

        public List<UserPassedCourse> ReadAll()
        {
            List<UserPassedCourse> userPassedCourseList = new();
            List<UserPassedCourseDboRelation> userPassedCourseDboList = userPassedCourseDboRelationsRepository.ReadAll();

            foreach (UserPassedCourseDboRelation userPassedCourseDbo in userPassedCourseDboList)
            {
                UserPassedCourse userPassedCourse = mapper.Map<UserPassedCourse>(userPassedCourseDbo);
                CourseDbo courseDbo = courseDboRepository.Read(userPassedCourseDbo.CourseId);
                userPassedCourse.CourseName = mapper.Map<Course>(courseDbo).Name;
                userPassedCourseList.Add(userPassedCourse);
            }

            return userPassedCourseList;
        }

        public int Update(int id, UserPassedCourse dataInstance)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            return userPassedCourseDboRelationsRepository.Delete(id);
        }
    }
}