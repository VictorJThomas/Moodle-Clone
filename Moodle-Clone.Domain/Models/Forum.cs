using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moodle_Clone.Domain.Models
{
    public class Forum
    {
        public Forum()
        {
            Answer = new HashSet<Answers>();
        }

        [Key]
        public Guid ForumId { get; set; }

        [ForeignKey("Courses")]
        public Guid CourseId { get; set; }
        public Courses Courses { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public virtual ICollection<Answers>? Answer { get; set; }
    }
}
