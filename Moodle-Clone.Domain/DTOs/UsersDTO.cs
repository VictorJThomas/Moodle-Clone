namespace Moodle_Clone.Domain.DTOs
{
    public class UsersDTO
    {
        public class RegisterUserDTO
        {
            public string Name { get; set; } = null!;
            public string Email { get; set; } = null!;
            public string Password { get; set; } = null!;
            public int RolId { get; set; }
        }

        public class LoginUserDTO
        {
            public string Email { get; set; }
            public string Password { get; set; }

            public string Token { get; set; }
        }

        public class UpdateUserDTO
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string ProfilePic { get; set;}
            public int RolId { get; set;}
        }
    }
}
