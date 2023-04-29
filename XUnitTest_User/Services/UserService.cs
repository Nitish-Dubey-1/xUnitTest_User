using XUnitTest_User.Data;
using XUnitTest_User.Model;

namespace XUnitTest_User.Services
{
    public class UserService : IUserService
    {
        public List<User> GetUsers()
        {
            return MockData.Users;
        }

        public bool DeleteUser(int userId)
        {
            if (MockData.Users.Any(u => u.UserId == userId))
            {
                int index = MockData.Users.FindIndex(u => u.UserId == userId);
                MockData.Users.RemoveAt(index);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateUserDetails(User usr)
        {
            var user = MockData.Users.Find(u => u.UserId == usr.UserId);
            if (user!=null)
            {
                int index = MockData.Users.FindIndex(u => u.UserId == usr.UserId);
                MockData.Users[index] = usr;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CreateUser(User usr)
        {
            
            if ((!MockData.Users.Any(u =>u.UserId == usr.UserId || u.Email == usr.Email)) && usr.UserId>0)
            {
                MockData.Users.Add(usr);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
