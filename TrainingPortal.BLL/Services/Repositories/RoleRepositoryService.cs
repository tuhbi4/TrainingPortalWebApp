using System.Collections.Generic;
using System.Linq;
using TrainingPortal.BLL.Interfaces;
using TrainingPortal.DAL.Dbo.Models;
using TrainingPortal.DAL.Interfaces;
using TrainingPortal.Entities.Models;

namespace TrainingPortal.BLL.Services.Repositories
{
    public class RoleRepositoryService : IRepositoryService<Role>
    {
        private readonly IModelMapper _modelMapper;
        private readonly IDboRepository<RoleDbo> _roleDboRepository;

        public RoleRepositoryService(IModelMapper modelMapper, IDboRepository<RoleDbo> roleRepository)
        {
            _modelMapper = modelMapper;
            _roleDboRepository = roleRepository;
        }

        public int Create(Role dataInstance)
        {
            return _roleDboRepository.Create(_modelMapper.ConvertToDboModel<Role, RoleDbo>(dataInstance));
        }

        public Role Read(int id)
        {
            return _modelMapper.ConvertToDomainModel<RoleDbo, Role>(_roleDboRepository.Read(id));
        }

        public List<Role> ReadAll()
        {
            IEnumerable<Role> roles = _roleDboRepository.ReadAll().Select(x => _modelMapper.ConvertToDomainModel<RoleDbo, Role>(x));
            List<Role> rolesList = new List<Role>();

            foreach (Role role in roles)
            {
                rolesList.Add(role);
            }

            return rolesList;
        }

        public int Update(int id, Role dataInstance)
        {
            return _roleDboRepository.Update(id, _modelMapper.ConvertToDboModel<Role, RoleDbo>(dataInstance));
        }

        public int Delete(int id)
        {
            return _roleDboRepository.Delete(id);
        }
    }
}