using System.Collections.Generic;
using TrainingPortal.BLL.Interfaces;
using TrainingPortal.DAL.Dbo.Models;
using TrainingPortal.DAL.Interfaces;
using TrainingPortal.Entities.Models;

namespace TrainingPortal.BLL.Services.Repositories
{
    public class CategoriesRepositoryService : IRepositoryService<Category>
    {
        private readonly IDboRepository<CategoryDbo> _repository;
        private readonly IModelMapper _modelMapper;

        public CategoriesRepositoryService(IDboRepository<CategoryDbo> repository, IModelMapper modelMapper)
        {
            _repository = repository;
            _modelMapper = modelMapper;
        }

        public int Create(Category dataInstance)
        {
            return _repository.Create(_modelMapper.ConvertToDboModel<Category, CategoryDbo>(dataInstance));
        }

        public Category Read(int id)
        {
            return _modelMapper.ConvertToDomainModel<CategoryDbo, Category>(_repository.Read(id));
        }

        public List<Category> ReadAll()
        {
            List<Category> categoryList = new();
            List<CategoryDbo> categoryDboList = _repository.ReadAll();
            foreach (CategoryDbo categoryDbo in categoryDboList)
            {
                categoryList.Add(_modelMapper.ConvertToDomainModel<CategoryDbo, Category>(categoryDbo));
            }

            return categoryList;
        }

        public int Update(int id, Category dataInstance)
        {
            return _repository.Update(id, _modelMapper.ConvertToDomainModel<Category, CategoryDbo>(dataInstance));
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}