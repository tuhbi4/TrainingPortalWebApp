using AutoMapper;
using TrainingPortal.BLL.Models;
using TrainingPortal.BLL.Models.CourseItems;
using TrainingPortal.BLL.Models.CourseItems.TestItems;
using TrainingPortal.BLL.Models.CourseItems.TestItems.TestQuestionItems;
using TrainingPortal.DAL.Dbo.CourseItems;
using TrainingPortal.DAL.Dbo.CourseItems.TestItems;
using TrainingPortal.DAL.Dbo.CourseItems.TestItems.TestQuestionItems;
using TrainingPortal.DAL.Dbo.Models;
using TrainingPortal.WebPL.Models.Course;
using TrainingPortal.WebPL.Models.User;

namespace TrainingPortal.WebPL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDbo>();
            CreateMap<UserDbo, User>();
            CreateMap<Role, RoleDbo>();
            CreateMap<RoleDbo, Role>();
            CreateMap<Course, CourseDbo>();
            CreateMap<CourseDbo, Course>();
            CreateMap<Category, CategoryDbo>();
            CreateMap<CategoryDbo, Category>();
            CreateMap<Test, TestDbo>();
            CreateMap<TestDbo, Test>();
            CreateMap<TargetAudience, TargetAudienceDbo>();
            CreateMap<TargetAudienceDbo, TargetAudience>();
            CreateMap<Lesson, LessonDbo>();
            CreateMap<LessonDbo, Lesson>();
            CreateMap<Certificate, CertificateDbo>();
            CreateMap<CertificateDbo, Certificate>();
            CreateMap<TestQuestion, TestQuestionDbo>();
            CreateMap<TestQuestionDbo, TestQuestion>();
            CreateMap<Answer, AnswerDbo>();
            CreateMap<AnswerDbo, Answer>();
            CreateMap<UserPassedCourse, UserPassedCourseDboRelation>();
            CreateMap<UserPassedCourseDboRelation, UserPassedCourse>();

            CreateMap<User, EditUserViewModel>();
            CreateMap<RegisterUserViewModel, User>();
            CreateMap<User, SettingsUserViewModel>();
            CreateMap<SettingsUserViewModel, User>();
            CreateMap<User, EditUserViewModel>();
            CreateMap<EditUserViewModel, User>();
            CreateMap<Course, CourseViewModel>();
            CreateMap<CourseViewModel, Course>();
        }
    }
}