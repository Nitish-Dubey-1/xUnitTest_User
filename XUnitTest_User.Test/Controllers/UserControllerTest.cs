using Moq;
using Xunit;
using XUnitTest_User.Controllers;
using XUnitTest_User.Model;
using XUnitTest_User.Services;

namespace XUnitTest_User.Test.Controllers
{
    public class UserControllerTest
    {

        private readonly Mock<IUserService> _mockUserService;
        private readonly UserController _controller;

        public UserControllerTest()
        {
            _mockUserService = new Mock<IUserService>();
            _controller = new UserController(_mockUserService.Object);
        }

        [Fact]
        public void GetAll_UserDetails_AsListOfUser()
        {
            //Arrange
            var expectedData = new List<User>() {
                    new User()
                    {
                        UserId = 1,
                        UserName = "Raj",
                        Password = "Raj@123",
                        Email = "raj@gmail.com"
                    },
                    new User()
                    {
                        UserId = 2,
                        UserName = "Raj",
                        Password = "Raj@123",
                        Email = "raj22@gmail.com"
                    }
                    };
            _mockUserService.Setup(u => u.GetUsers()).Returns(expectedData);
         
            
            //Act
            List<User> result = _controller.GetUsersDetails();

            //Assert
            Assert.Equal(expectedData, result);
            Assert.IsType<List<User>>(result);

        }

        [Theory]
        [InlineData(6,true)]
        [InlineData(1000,false)]
        [InlineData(-10,false)]
        [InlineData(0,false)]
        public void DeleteUser_ReturnBool(int userId,bool correctRes)
        {
            //Arrange
            _mockUserService.Setup(u => u.DeleteUser(userId)).Returns(correctRes);

            //Act
            bool result = _controller.RemoveUser(userId);

            //Assert
            Assert.Equal(correctRes, result);
        }

        [Theory]
        [MemberData(nameof(MockForUpdate))]
        public void UpdateUserDetails_ReturnBool(User user, bool correctRes)
        {
            //Arrange
            _mockUserService.Setup(u => u.UpdateUserDetails(user)).Returns(correctRes);

            //Act
            bool result = _controller.UpdateUserDetails(user);

            //Assert
            Assert.Equal(correctRes, result);
        }

        [Theory]
        [MemberData(nameof(MockForCreate))]
       public void CreateNewUser_ReturnBool(User user, bool correctRes)
        {
            //Arrange
            _mockUserService.Setup(u => u.CreateUser(user)).Returns(correctRes);

            //Act
            bool result = _controller.CreateNewUser(user);

            //Assert
            Assert.Equal(correctRes, result);
        }

    public static IEnumerable<object[]> MockForCreate
        {
            get
            {
                yield return new object[]
                {
                    new User()
                    {
                        UserId = 1,
                        UserName = "Raj",
                        Password = "Raj@123",
                        Email = "raj@gmail.com"
                    },false
                };
                yield return new object[]
                {
                        new User()
                        {
                            UserId = -1,
                            UserName = "Anish11",
                            Password = "Anish11@123",
                            Email = "anish11@gmail.com"
                        },false
                }; 
                yield return new object[]
                {
                        new User()
                        {
                            UserId = 0,
                            UserName = "Abhinash",
                            Password = "Abhinash@123",
                            Email = "abhinash"
                        },false
                };
                yield return new object[]
                {
                        new User()
                        {
                           UserId = 7,
                           UserName = "Sammy",
                           Password = "Sammy@123",
                           Email = "sammy@gmail.com"
                        },true
                };
            }
        }

        public static IEnumerable<object[]> MockForUpdate
        {
            get
            {
                yield return new object[]
                {
                    new User()
                    {
                        UserId = 2,
                        UserName = "Raj",
                        Password = "Raj@123",
                        Email = "raj22@gmail.com"
                    },true
                };
                yield return new object[]
                {
                        new User()
                        {
                            UserId = -2,
                            UserName = "Anish11",
                            Password = "Anish11@123",
                            Email = "anish113@gmail.com"
                        },false
                };
                yield return new object[]
                {
                        new User()
                        {
                            UserId = -100,
                            UserName = "Abhinash",
                            Password = "Abhinash@123",
                            Email = "abhinash48@gmail.com"
                        },false
                };
                yield return new object[]
                {
                        new User()
                        {
                           UserId = 100,
                           UserName = "Sammy",
                           Password = "Sammy@123",
                           Email = "sammy67@gmail.com"
                        },false
                };
            }
        }
    }
}
