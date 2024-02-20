using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moodle_Clone.Domain.Models
{
    public class Resources
    {
        [Key]
        public Guid ResourcesId { get; set; }

        [ForeignKey("Courses")]
        public Guid CourseId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? File { get; set; }
    }
}
