using System.ComponentModel.DataAnnotations;

namespace Moodle_Clone.Domain.Models
{
    public class Users
    {
        [Key]
        public Guid UserId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? ProfilePic { get; set; }
        public int? RolId { get; set; }

        public virtual Role? Rol { get; set; }
        public virtual Student? Student { get; set; }
        public virtual Teacher? Teacher { get; set; }
    }
}