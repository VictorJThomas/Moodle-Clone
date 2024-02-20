using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moodle_Clone.Domain.Models
{
    public class Assignments
    {
        [Key]
        public Guid AssignmentsId { get; set; }
        [ForeignKey("Courses")]
        public Guid? CourseId { get; set; }
        [ForeignKey("Teacher")]
        public Guid? TeacherId { get; set; }
        public string AssignmentsName { get; set; } = null!;
        public string? AssignmentsDescription { get; set; }
        public bool AssignmentsStatus { get; set; }
        public string? File { get; set; }
        public DateTime LimitDate { get; set; }

        public virtual Courses? Course { get; set; }
        public virtual Teacher? Teacher { get; set; }
        public virtual ICollection<Student>? SubmittedBy { get; set; }
    }
}
