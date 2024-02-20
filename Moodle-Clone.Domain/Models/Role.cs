using System.ComponentModel.DataAnnotations;

namespace Moodle_Clone.Domain.Models
{
    public class Role
    {
        public Role()
        {
            User = new HashSet<Users>();
        }

        [Key]
        public int RolId { get; set; }
        public string RoleName { get; set; } = null!;
        public virtual ICollection<Users> User { get; set; }
    }
}
