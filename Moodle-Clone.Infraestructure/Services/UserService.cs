using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Moodle_Clone.Domain.Interfaces;
using Moodle_Clone.Domain.Models;
using Moodle_Clone.Infraestructure.Context;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static Moodle_Clone.Domain.DTOs.UsersDTO;

namespace Moodle_Clone.Infraestructure.Services
{
    public class UserService : IUsersService
    {
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;

        public UserService(DatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }


        public async Task<(bool, string)> LoginUser(LoginUserDTO loginUserDTO)
        {
            if (string.IsNullOrEmpty(loginUserDTO.Email) || string.IsNullOrEmpty(loginUserDTO.Password))
            {
                throw new ArgumentException("Email and Password are required.");
            }

            Users? user = await _context.Users
                .Include(u => u.Rol)
                .FirstOrDefaultAsync(u => u.Email == loginUserDTO.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(loginUserDTO.Password, user.Password))
            {
                return (false, "Invalid login credentials.");
            }

            string token = CreateJWTToken(user);

            return (true, token);

        }

        public async Task RegisterUser(RegisterUserDTO registerUserDTO)
        {
            if(!await _context.Role.AnyAsync(r => r.RolId == registerUserDTO.RolId))
            {
                throw new Exception("Invalid Role ID");
            }

            registerUserDTO.Password = BCrypt.Net.BCrypt.HashPassword(registerUserDTO.Password);

            var user = new Users
            {
                Name = registerUserDTO.Name,
                Email = registerUserDTO.Email,
                Password = registerUserDTO.Password,
                RolId = registerUserDTO.RolId
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            string token = CreateJWTToken(user);
        }

        private string CreateJWTToken(Users users)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, users.Name),
                new Claim(ClaimTypes.Role, "Student"),
                new Claim(ClaimTypes.Role, "Teacher"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,  
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
