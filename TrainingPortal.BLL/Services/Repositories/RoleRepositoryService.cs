using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using TrainingPortal.BLL.Interfaces;
using TrainingPortal.BLL.Models;
using TrainingPortal.DAL.Dbo.Models;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.BLL.Services.Repositories
{
    public class RoleRepositoryService : IRepositoryService<Role>
    {
        private readonly IMapper mapper;
        private readonly IDboRepository<RoleDbo> roleDboRepository;

        public RoleRepositoryService(IMapper mapper, IDboRepository<RoleDbo> roleRepository)
        {
            this.mapper = mapper;
            roleDboRepository = roleRepository;
        }

        public int Create(Role dataInstance)
        {
            return roleDboRepository.Create(mapper.Map<RoleDbo>(dataInstance));
        }

        public Role Read(int id)
        {
            return mapper.Map<Role>(roleDboRepository.Read(id));
        }

        public List<Role> ReadAll()
        {
            IEnumerable<Role> roles = roleDboRepository.ReadAll().Select(x => mapper.Map<Role>(x));
            List<Role> rolesList = new List<Role>();

            foreach (Role role in roles)
            {
                rolesList.Add(role);
            }

            return rolesList;
        }

        public int Update(int id, Role dataInstance)
        {
            return roleDboRepository.Update(id, mapper.Map<RoleDbo>(dataInstance));
        }

        public int Delete(int id)
        {
            return roleDboRepository.Delete(id);
        }
    }
}