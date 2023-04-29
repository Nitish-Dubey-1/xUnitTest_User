using XUnitTest_User.Model;

namespace XUnitTest_User.Data
{
    public class MockData
    {
        public static List<User> Users = new List<User>()
        {
            new User()
            {
                UserId=1,
                UserName="Raj",
                Password="Raj@123",
                Email="raj888@gmail.com"
            },
            new User()
            {
                UserId=2,
                UserName="Anish",
                Password="Anish@123",
                Email="anish@gmail.com"
            },
            new User()
            {
                UserId=3,
                UserName="Abhinash",
                Password="Abhinash@123",
                Email="abhinash@gmail.com"
            },
            new User()
            {
                UserId=4,
                UserName="Sam",
                Password="Sam@123",
                Email="sam@gmail.com"
            },
            new User()
            {
                UserId=5,
                UserName="Samay",
                Password="Samay@123",
                Email="samay@gmail.com"
            },
            new User()
            {
                UserId=6,
                UserName="Sanjay",
                Password="Sanjay@123",
                Email="sanjay@gmail.com"
            }
        };
    }
}
