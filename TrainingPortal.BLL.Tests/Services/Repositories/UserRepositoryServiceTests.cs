using AutoMapper;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TrainingPortal.BLL.Models;
using TrainingPortal.BLL.Services.Repositories;
using TrainingPortal.DAL.Dbo.Models;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.BLL.Tests.Services.Repositories
{
    [TestFixture]
    public class UserRepositoryServiceTests
    {
        private MockRepository mockRepository;

        private Mock<IMapper> mockmapper;
        private Mock<IDboRepository<UserDbo>> mockDboRepositoryUserDbo;
        private Mock<IDboRepository<RoleDbo>> mockDboRepositoryRoleDbo;

        [SetUp]
        public void SetUp()
        {
            mockRepository = new MockRepository(MockBehavior.Default);

            mockmapper = mockRepository.Create<IMapper>();
            mockDboRepositoryUserDbo = mockRepository.Create<IDboRepository<UserDbo>>();
            mockDboRepositoryRoleDbo = mockRepository.Create<IDboRepository<RoleDbo>>();
        }

        [Test]
        public void Create_WhenRepoReturnsOne_ReturnsOne()
        {
            // Arrange
            var service = CreateService();
            User userDataInstance = null;
            UserDbo userDboDataInstance = null;
            mockDboRepositoryUserDbo.Setup(x => x.Create(userDboDataInstance)).Returns(1);

            // Act
            var actualResult = service.Create(
                userDataInstance);

            // Assert
            Assert.AreEqual(1, actualResult);
        }

        [Test]
        public void Create_WhenRepoReturnsZero_ReturnsZero()
        {
            // Arrange
            var service = CreateService();
            User userDataInstance = null;
            UserDbo userDboDataInstance = null;
            mockDboRepositoryUserDbo.Setup(x => x.Create(userDboDataInstance)).Returns(0);

            // Act
            var actualResult = service.Create(
                userDataInstance);

            // Assert
            Assert.AreEqual(0, actualResult);
        }

        [TestCase(1, ExpectedResult = 1)]
        [TestCase(2, ExpectedResult = 2)]
        public int Read_WhenProvideId_ReturnsUserWithCorrectId(int id)
        {
            // Arrange
            var service = CreateService();
            UserDbo sourceInstance = new();
            User resultInstance = new();
            resultInstance.Id = id;
            resultInstance.Role = new Role { Id = 0, Name = string.Empty };
            mockDboRepositoryUserDbo.Setup(x => x.Read(id)).Returns(sourceInstance);
            mockmapper.Setup(x => x.Map<User>(sourceInstance)).Returns(resultInstance);

            // Act
            var actualResult = service.Read(
                id);

            // Assert
            return actualResult.Id;
        }

        [Test]
        public void ReadAll_ReturnsActualList()
        {
            // Arrange
            var service = CreateService();
            mockDboRepositoryUserDbo.Setup(x => x.ReadAll()).Returns(GetTestUserDboList());
            mockDboRepositoryRoleDbo.Setup(x => x.Read(It.IsAny<int>())).Returns<int>(id => GetTestRoleDboList()[id - 1]);
            mockmapper.Setup(x => x.Map<User>(It.IsAny<UserDbo>())).Returns<UserDbo>(userDbo => GetTestUserList()[userDbo.Id - 1]);
            mockmapper.Setup(x => x.Map<Role>(It.IsAny<RoleDbo>())).Returns<RoleDbo>(roleDbo => GetTestRoleList()[roleDbo.Id - 1]);

            // Act
            var actualResult = service.ReadAll();

            // Assert
            Assert.AreEqual(GetTestUserList().Count, actualResult.Count);
        }

        private UserService CreateService()
        {
            return new UserService(
                mockmapper.Object,
                mockDboRepositoryUserDbo.Object,
                mockDboRepositoryRoleDbo.Object);
        }

        private List<User> GetTestUserList()
        {
            var users = new List<User>
            {
                new User { Id = 1, Login = "user1", PasswordHash = "password1", Email = "email1",
                    Role = new Role { Id = 1, Name = "user" }, Lastname = "lastname1", Firstname = "firstname1", Patronymic = "patronymic1" },
                new User { Id = 2, Login = "user2", PasswordHash = "password2", Email = "email2",
                    Role = new Role { Id = 1, Name = "user" }, Lastname = "lastname2", Firstname = "firstname2", Patronymic = "patronymic2" },
                new User { Id = 3, Login = "user3", PasswordHash = "password3", Email = "email3",
                    Role = new Role { Id = 1, Name = "user" }, Lastname = "lastname3", Firstname = "firstname3", Patronymic = "patronymic3" },
            };

            return users;
        }

        private List<UserDbo> GetTestUserDboList()
        {
            var users = new List<UserDbo>
            {
                new UserDbo { Id = 1, Login = "user1", PasswordHash = "password1", Email = "email1", RoleId = 1,
                    Lastname = "lastname1", Firstname = "firstname1", Patronymic = "patronymic1" },
                new UserDbo { Id = 2, Login = "user2", PasswordHash = "password2", Email = "email2", RoleId = 2,
                    Lastname = "lastname2", Firstname = "firstname2", Patronymic = "patronymic2" },
                new UserDbo { Id = 3, Login = "user3", PasswordHash = "password3", Email = "email3", RoleId = 3,
                    Lastname = "lastname3", Firstname = "firstname3", Patronymic = "patronymic3" },
            };

            return users;
        }

        private List<RoleDbo> GetTestRoleDboList()
        {
            var roles = new List<RoleDbo>
            {
                new RoleDbo{ Id = 1, Name = "user" },
                new RoleDbo{ Id = 2, Name = "manager" },
                new RoleDbo{ Id = 3, Name = "admin" },
            };

            return roles;
        }

        private List<Role> GetTestRoleList()
        {
            var roles = new List<Role>
            {
                new Role{ Id = 1, Name = "user" },
                new Role{ Id = 2, Name = "manager" },
                new Role{ Id = 3, Name = "admin" },
            };

            return roles;
        }
    }
}