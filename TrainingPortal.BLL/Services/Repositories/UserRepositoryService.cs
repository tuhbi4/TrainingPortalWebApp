using AutoMapper;
using System.Collections.Generic;
using TrainingPortal.BLL.Interfaces;
using TrainingPortal.BLL.Models;
using TrainingPortal.DAL.Dbo.Models;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.BLL.Services.Repositories
{
    public class UserRepositoryService : IRepositoryService<User>
    {
        private readonly IMapper mapper;
        private readonly IDboRepository<UserDbo> userRepository;
        private readonly IDboRepository<RoleDbo> roleRepository;

        public UserRepositoryService(IMapper mapper, IDboRepository<UserDbo> userRepository, IDboRepository<RoleDbo> roleRepository)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
        }

        public int Create(User dataInstance)
        {
            UserDbo mappedInstance = mapper.Map<UserDbo>(dataInstance);
            return userRepository.Create(mappedInstance);
        }

        public User Read(int id)
        {
            return mapper.Map<User>(userRepository.Read(id));
        }

        public List<User> ReadAll()
        {
            List<User> userList = new();
            List<UserDbo> userDboList = userRepository.ReadAll();
            foreach (UserDbo userDbo in userDboList)
            {
                User user = mapper.Map<User>(userDbo);
                RoleDbo roleDbo = roleRepository.Read(userDbo.RoleId);
                user.Role = mapper.Map<Role>(roleDbo);
                userList.Add(user);
            }

            return userList;
        }

        public int Update(int id, User dataInstance)
        {
            return userRepository.Update(id, mapper.Map<UserDbo>(dataInstance));
        }

        public int Delete(int id)
        {
            return userRepository.Delete(id);
        }
    }
}