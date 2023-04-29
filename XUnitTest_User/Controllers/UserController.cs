
using Microsoft.AspNetCore.Mvc;
using XUnitTest_User.Model;
using XUnitTest_User.Services;

namespace XUnitTest_User.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetUsersDetails")]
        public List<User> GetUsersDetails()
        {
            return _userService.GetUsers();
        }

        [HttpDelete("DeleteUser")]
        public bool RemoveUser(int userId)
        {
            return _userService.DeleteUser(userId);
        }

        [HttpPatch("UpdateUserDetails")]
        public bool UpdateUserDetails(User usr)
        {
            return _userService.UpdateUserDetails(usr);
        }

        [HttpPost("CreateNewUser")]
        public bool CreateNewUser(User usr)
        {
            return _userService.CreateUser(usr);
        }
    }
}
