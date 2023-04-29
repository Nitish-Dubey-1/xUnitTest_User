using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using XUnitTest_User.Controllers;
using XUnitTest_User.Model;
using XUnitTest_User.Services;

namespace XUnitTest_User.Test.Services
{
    public class UserServiceTest
    {
        [Fact]
        public void GetAllUsers_ReturnListOfUser()
        {
            //Arrange
            UserService service = new UserService();

            //Act
            List<User> result = service.GetUsers();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<User>>(result);
        }

        [Theory]
        [InlineData(0,false)]
        [InlineData(5, true)]
        [InlineData(-1, false)]
        [InlineData(4, true)]
        [InlineData(100, false)]
        public void DeleteUser(int userId,bool correctRes)
        {
            //Arrange
            UserService service = new UserService();

            //Act
            bool result = service.DeleteUser(userId);

            //Assert
            Assert.Equal(correctRes,result);
        }

        [Theory]
        [MemberData(nameof(MockForUpdate))]
        public void UpdateUserDetails_ReturnBool(User usr,bool correctRes)
        {
            //Arrange
            UserService service = new UserService();

            //Act
            bool result = service.UpdateUserDetails(usr);

            //Assert
            Assert.Equal(correctRes, result);
        }

        [Theory]
        [MemberData(nameof(MockForCreate))]
        public void CreateUser_ReturnBool(User usr,bool correctRes)
        {
            //Arrange
            UserService service = new UserService();

            //Act
            bool result = service.CreateUser(usr);

            //Assert
            Assert.Equal(correctRes, result);
        }

        public static IEnumerable<object[]> MockForUpdate
        {
            get
            {
                yield return new object[]
                {
                    new User()
                    {
                        UserId = 3,
                        UserName = "Raj",
                        Password = "Raj@123",
                        Email = "raj@gmail.com"
                    },true
                };
                yield return new object[]
                {
                        new User()
                        {
                            UserId = -6,
                            UserName = "Anish11",
                            Password = "Anish11@123",
                            Email = "anish11@gmail.com"
                        },false
                };
                yield return new object[]
                {
                        new User()
                        {
                            UserId = -102,
                            UserName = "Abhinash",
                            Password = "Abhinash@123",
                            Email = "abhinash"
                        },false
                };
                yield return new object[]
                {
                        new User()
                        {
                           UserId = 2000,
                           UserName = "Sammy",
                           Password = "Sammy@123",
                           Email = "sammy@gmail.com"
                        },false
                };
            }
        }
        public static IEnumerable<object[]> MockForCreate
        {
            get
            {
                yield return new object[]
                {
                    new User()
                    {
                        UserId = 8,
                        UserName = "Raj",
                        Password = "Raj@123",
                        Email = "raj@gmail.com"
                    },true
                };
                yield return new object[]
                {
                        new User()
                        {
                            UserId = -1000,
                            UserName = "Anish11",
                            Password = "Anish11@123",
                            Email = "anish11@gmail.com"
                        },false
                };
                yield return new object[]
                {
                        new User()
                        {
                            UserId = 200,
                            UserName = "Abhinash",
                            Password = "Abhinash@123",
                            Email = "abhinash"
                        },true
                };
                yield return new object[]
                {
                        new User()
                        {
                           UserId = 1,
                           UserName = "Sammy",
                           Password = "Sammy@123",
                           Email = "sammy@gmail.com"
                        },false
                };
            }
        }
    }
}
