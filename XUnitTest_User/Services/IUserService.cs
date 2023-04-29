using XUnitTest_User.Model;

namespace XUnitTest_User.Services
{
    public interface IUserService
    {
        public List<User> GetUsers();
        public bool DeleteUser(int userId);
        public bool UpdateUserDetails(User usr);
        public bool CreateUser(User usr);
    }
}
