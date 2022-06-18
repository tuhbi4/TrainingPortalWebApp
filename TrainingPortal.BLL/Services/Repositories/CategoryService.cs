using AutoMapper;
using System.Collections.Generic;
using TrainingPortal.BLL.Interfaces;
using TrainingPortal.BLL.Models;
using TrainingPortal.DAL.Dbo.Models;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.BLL.Services.Repositories
{
    public class CategoryService : IRepositoryService<Category>
    {
        private readonly IDboRepository<CategoryDbo> repository;
        private readonly IMapper mapper;

        public CategoryService(IDboRepository<CategoryDbo> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public int Create(Category dataInstance)
        {
            return repository.Create(mapper.Map<CategoryDbo>(dataInstance));
        }

        public Category Read(int id)
        {
            return mapper.Map<Category>(repository.Read(id));
        }

        public List<Category> ReadAll()
        {
            List<Category> categoryList = new();
            List<CategoryDbo> categoryDboList = repository.ReadAll();

            foreach (CategoryDbo categoryDbo in categoryDboList)
            {
                categoryList.Add(mapper.Map<Category>(categoryDbo));
            }

            return categoryList;
        }

        public int Update(int id, Category dataInstance)
        {
            return repository.Update(id, mapper.Map<CategoryDbo>(dataInstance));
        }

        public int Delete(int id)
        {
            return repository.Delete(id);
        }
    }
}