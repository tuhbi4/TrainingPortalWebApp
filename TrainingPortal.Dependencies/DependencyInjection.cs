using Microsoft.Extensions.DependencyInjection;
using TrainingPortal.BLL.Interfaces;
using TrainingPortal.BLL.Services;
using TrainingPortal.DAL.Interfaces;
using TrainingPortal.DAL.Mocks;
using TrainingPortal.Entities;

namespace TrainingPortal.Dependencies
{
    public static class DependencyInjection
    {
        public static void InjectDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IRepository<Category>, MockRepository<Category>>();
            services.AddSingleton<IRepositoryService<Category>, RepositoryService<Category>>();
            services.AddSingleton<IRepository<Course>, MockRepository<Course>>();
            services.AddSingleton<IRepositoryService<Course>, RepositoryService<Course>>();
        }
    }
}