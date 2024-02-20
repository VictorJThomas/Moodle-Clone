using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moodle_Clone.Domain.Models
{
    public class Answers
    {
        [Key]
        public Guid AnswerId { get; set; }
        [ForeignKey("Forum")]
        public Guid ForumId { get; set; }
        [ForeignKey("Student")]
        public Guid StudentId { get; set; }
        public string AnswerText { get; set; } = null!;

        public virtual Forum? Forum { get; set; }
        public virtual Student? Student { get; }
    }
}
