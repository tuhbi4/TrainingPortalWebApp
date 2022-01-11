using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrainingPortal.BLL.Interfaces;
using TrainingPortal.BLL.Models;
using TrainingPortal.BLL.Services;
using TrainingPortal.BLL.Services.Repositories;
using TrainingPortal.DAL.Dbo.CourseItems;
using TrainingPortal.DAL.Dbo.CourseItems.TestItems;
using TrainingPortal.DAL.Dbo.CourseItems.TestItems.TestQuestionItems;
using TrainingPortal.DAL.Dbo.Models;
using TrainingPortal.DAL.Interfaces;
using TrainingPortal.Entities;
using TrainingPortal.SqlDAL;
using TrainingPortal.SqlDAL.Repositories;

namespace TrainingPortal.Dependencies
{
    public static class DependencyInjection
    {
        public static void InjectDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IHashService, MD5HashService>();
            services.AddSingleton<IDboModelMapper, SqlDboModelMapper>();
            services.AddSingleton<IDbCommandPerformer, SqlDbCommandPerformer>();
            services.AddSingleton<IDboRepository<CategoryDbo>, CategoriesDboRepository>();
            services.AddSingleton<IDboRepository<CourseDbo>, CoursesDboRepository>();
            services.AddSingleton<IDboRepository<RoleDbo>, RolesDboRepository>();
            services.AddSingleton<IDboRepository<UserDbo>, UsersDboRepository>();
            services.AddSingleton<IDboRepository<CertificateDbo>, CertificatesDboRepository>();
            services.AddSingleton<IDboRepository<LessonDbo>, LessonsDboRepository>();
            services.AddSingleton<IDboRepository<TargetAudienceDbo>, TargetAudienciesDboRepository>();
            services.AddSingleton<IDboRepository<TestDbo>, TestsDboRepository>();
            services.AddSingleton<IDboInnerRepository<AnswerDbo>, AnswersDboInnerRepository>();
            services.AddSingleton<IDboInnerRepository<TestQuestionDbo>, QuestionsDboInnerRepository>();
            services.AddSingleton<IDboRelationsRepository<CoursesLessonsDboRelation>, CoursesLessonsDboRelationsRepository>();
            services.AddSingleton<IDboRelationsRepository<CoursesTargetAudienciesDboRelation>, CoursesTargetAudienciesDboRelationsRepository>();
            services.AddSingleton<IRepositoryService<Category>, CategoriesRepositoryService>();
            services.AddSingleton<IRepositoryService<Course>, CourseRepositoryService>();
            services.AddSingleton<IRepositoryService<User>, UserRepositoryService>();
            services.AddSingleton<IRepositoryService<Role>, RoleRepositoryService>();
        }

        public static void InjectDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(new ConnectionSettings
            {
                ConnectionString = configuration.GetConnectionString("DefaultConnection"),
            });
            services.AddSingleton(new AzureSettings
            {
                ConnectionString = configuration.GetSection("AzureSettings:ConnectionString").Value,
                ImageContainerName = configuration.GetSection("AzureSettings:ImageContainerName").Value
            });
        }
    }
}