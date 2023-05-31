using AutoMapper;
using CookingHut.Domain.Entities;
using CookingHut.Infra.Data.Context;
using CookingHut.Infra.Data.Repositories.Interfaces;
using CookingHut.Services.Mapping.Dtos;
using CookingHut.Services.Services.Implementations;
using Moq;
using Xunit;

namespace CookingHut.Tests
{
    public class UserServiceTests
    {
        public class UserServiceTest

        //returnar user com o id 1
        {
            [Fact]
            public async Task GetAll_ShouldReturnAllUsers_SuccessAsync()
            {
                // Arrange

                List<User> usersInDatabase = new List<User>()
                {
                    new User
                    {
                        Id = 1,
                        Name = "Test",
                        Email = "Test",
                        Password = "Test"
                    },
                    new User
                    {
                        Id = 2,
                        Name = "Test 2",
                        Email = "Test 2",
                        Password = "Test 2"
                    }
                };

                Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
                Mock<IMapper> mapperMock = new Mock<IMapper>();
                Mock<CookingHutDBContext> cookingHutDBContextMock = new Mock<CookingHutDBContext>();

                userRepositoryMock.Setup(mock => mock.GetAll()).ReturnsAsync(usersInDatabase);

                // Act

                var userService = new UserService(mapperMock.Object, userRepositoryMock.Object, cookingHutDBContextMock.Object);
                var usersResult = await userService.GetAll();

                // Assert

                mapperMock.Verify(x => x.Map<List<UserDto>>(usersInDatabase), Times.Once);
            }

            [Fact]
            public async Task GetLogin_WhenUserIsNull_ShouldReturnNull()
            {
                // Arrange

                UserLogin userLogin = new UserLogin()
                {
                    Email = "email@email.com",
                    Password = "password"
                };

                Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
                Mock<IMapper> mapperMock = new Mock<IMapper>();
                Mock<CookingHutDBContext> cookingHutDBContextMock = new Mock<CookingHutDBContext>();

                userRepositoryMock.Setup(mock => mock.GetLogin("email@email.com", "password")).Returns<User>(null);

                // Act

                var userService = new UserService(mapperMock.Object, userRepositoryMock.Object, cookingHutDBContextMock.Object);
                var result = userService.GetLogin(userLogin);

                // Assert

                Assert.Null(result);
            }

            [Fact]
            public async Task GetLogin_WhenUserIsNotNull_ShouldReturnUserLogged()
            {
                // Arrange

                UserLogin userLogin = new UserLogin()
                {
                    Email = "email@email.com",
                    Password = "password"
                };

                User user = new User
                {
                    Id = 1,
                    Name = "Daniela Filipa Oliveira",
                    Email = "email@email.com",
                    Password = "password",
                    IsAdministrator = true,
                };

                Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
                Mock<IMapper> mapperMock = new Mock<IMapper>();
                Mock<CookingHutDBContext> cookingHutDBContextMock = new Mock<CookingHutDBContext>();

                userRepositoryMock.Setup(mock => mock.GetLogin("email@email.com", "password")).Returns(user);

                // Act

                var userService = new UserService(mapperMock.Object, userRepositoryMock.Object, cookingHutDBContextMock.Object);
                var result = userService.GetLogin(userLogin);

                // Assert

                Assert.NotNull(result);
                Assert.Equal(user.Id, result.Id);
                Assert.Equal(user.Email, result.Email);
                Assert.Equal(user.Password, result.Password);
                Assert.Equal(user.Name.Substring(0, 20), result.Name);
                Assert.Equal(user.IsAdministrator, result.isAdministrator);
            }
        }
    }
}