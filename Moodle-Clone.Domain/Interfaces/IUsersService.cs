using static Moodle_Clone.Domain.DTOs.UsersDTO;

namespace Moodle_Clone.Domain.Interfaces
{
    public interface IUsersService
    {
        Task RegisterUser(RegisterUserDTO user);

        Task<(bool, string)> LoginUser(LoginUserDTO request);

        // Task UpdateUser(Guid Id, UpdateUserDTO user);
    }
}