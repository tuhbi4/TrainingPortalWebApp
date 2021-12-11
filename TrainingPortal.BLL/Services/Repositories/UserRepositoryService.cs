using System.Collections.Generic;
using TrainingPortal.BLL.Interfaces;
using TrainingPortal.DAL.Dbo.Models;
using TrainingPortal.DAL.Interfaces;
using TrainingPortal.Entities.Models;

namespace TrainingPortal.BLL.Services.Repositories
{
    public class UserRepositoryService : IRepositoryService<User>
    {
        private readonly IModelMapper _modelMapper;
        private readonly IDboRepository<UserDbo> _userRepository;
        private readonly IDboRepository<RoleDbo> _roleRepository;

        public UserRepositoryService(IModelMapper modelMapper, IDboRepository<UserDbo> userRepository, IDboRepository<RoleDbo> roleRepository)
        {
            _modelMapper = modelMapper;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public int Create(User dataInstance)
        {
            return _userRepository.Create(_modelMapper.ConvertToDboModel<User, UserDbo>(dataInstance));
        }

        public User Read(int id)
        {
            return _modelMapper.ConvertToDomainModel<UserDbo, User>(_userRepository.Read(id));
        }

        public List<User> ReadAll()
        {
            List<User> userList = new();
            List<UserDbo> userDboList = _userRepository.ReadAll();
            foreach (UserDbo userDbo in userDboList)
            {
                User user = _modelMapper.ConvertToDomainModel<UserDbo, User>(userDbo);
                user.UpdateRole(_modelMapper.ConvertToDomainModel<RoleDbo, Role>(_roleRepository.Read(userDbo.RoleId)));
                userList.Add(user);
            }

            return userList;
        }

        public int Update(int id, User dataInstance)
        {
            return _userRepository.Update(id, _modelMapper.ConvertToDboModel<User, UserDbo>(dataInstance));
        }

        public int Delete(int id)
        {
            return _userRepository.Delete(id);
        }
    }
}