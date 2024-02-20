using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moodle_Clone.Domain.Models
{
    public class Teacher
    {
        public Teacher()
        {
            Assignment = new HashSet<Assignments>();
            Course = new HashSet<Courses>();
        }
        [Key]
        public Guid TeacherId { get; set; }

        [ForeignKey("Users")]
        public Guid? UserId { get; set; }

        public virtual Users? Users { get; set; }
        public virtual ICollection<Courses> Course { get; set; }
        public virtual ICollection<Assignments> Assignment { get; set; }
    }
}
