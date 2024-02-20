using Moodle_Clone.Domain.Models;
using Riok.Mapperly.Abstractions;
using static Moodle_Clone.Domain.DTOs.UsersDTO;

namespace Moodle_Clone.Infraestructure.Mapping
{
    [Mapper]
    public partial class UserMapper
    {
        public Users MapUsers(RegisterUserDTO registerUserDto)
        {
            var mapper = RegisterUserToUser(registerUserDto);
            return mapper;
        }

        private partial Users RegisterUserToUser(RegisterUserDTO user);

        public RegisterUserDTO MapRegisterUserDTO(Users user) =>
            UserToRegisterUserDTO(user);

        [MapProperty(nameof(Users.Name), nameof(RegisterUserDTO.Name))]
        [MapProperty(nameof(Users.Email), nameof(RegisterUserDTO.Email))]
        [MapProperty(nameof(Users.Password), nameof(RegisterUserDTO.Password))]
        [MapProperty(nameof(Users.RolId), nameof(RegisterUserDTO.RolId))]

        [MapProperty(nameof(RegisterUserDTO.Name), nameof(Users.Name))]
        [MapProperty(nameof(RegisterUserDTO.Email), nameof(Users.Email))]
        [MapProperty(nameof(RegisterUserDTO.Password), nameof(Users.Password))]
        [MapProperty(nameof(RegisterUserDTO.RolId), nameof(Users.RolId))]

        private partial RegisterUserDTO UserToRegisterUserDTO(Users user);

        public UpdateUserDTO MapUpdateUserDTO(Users user)
        {
            var mapper = UserToUpdateUserDTO(user);
            return mapper;
        }

        [MapProperty(nameof(Users.Name), nameof(UpdateUserDTO.Name))]
        [MapProperty(nameof(Users.Email), nameof(UpdateUserDTO.Email))]
        [MapProperty(nameof(Users.Password), nameof(UpdateUserDTO.Password))]
        [MapProperty(nameof(Users.ProfilePic), nameof(UpdateUserDTO.ProfilePic))]
        [MapProperty(nameof(Users.RolId), nameof(UpdateUserDTO.RolId))]

        [MapProperty(nameof(UpdateUserDTO.Name), nameof(Users.Name))]
        [MapProperty(nameof(UpdateUserDTO.Email), nameof(Users.Email))]
        [MapProperty(nameof(UpdateUserDTO.Password), nameof(Users.Password))]
        [MapProperty(nameof(UpdateUserDTO.ProfilePic), nameof(Users.ProfilePic))]
        [MapProperty(nameof(UpdateUserDTO.RolId), nameof(Users.RolId))]

        private partial UpdateUserDTO UserToUpdateUserDTO(Users user);

        public LoginUserDTO MapLoginUserDTO(Users user) => UserToLoginUserDTO(user);

        private partial LoginUserDTO UserToLoginUserDTO(Users user);
    }
}