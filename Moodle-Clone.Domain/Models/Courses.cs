using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moodle_Clone.Domain.Models
{
    public class Courses
    {
        public Courses()
        {
            Assignment = new HashSet<Assignments>();
            Students = new HashSet<Student>();
            Resource = new HashSet<Resources>();
            Forums = new HashSet<Forum>();
        }

        [Key]
        public Guid CourseId { get; set; }
        public string CourseName { get; set; } = null!;
        public string? CourseDescription { get; set; }

        [ForeignKey("Teacher")]
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Forum> Forums { get; set; }
        public virtual ICollection<Resources>? Resource { get; set; }
        public virtual ICollection<Assignments> Assignment { get; set; }
    }
}
