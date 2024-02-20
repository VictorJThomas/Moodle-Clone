namespace Moodle_Clone.Domain.DTOs
{
    public class TeacherDTO
    {
        public class TeacheOnlyCourseDTO
        {
            public Guid TeacherID { get; set; }
        }

        public class TeacherCoursesDTO
        {
            public Guid TeacherId { get; set; }
            public Guid CourseId { get; set; }
        }

        public class PublishAssigmentDTO
        {
            public Guid AssignmentsId { get; set; }
            public Guid TeacherId { get; set; }
            public string AssignmentsName { get; set; }
            public string AssignmentsDescription { get; set; }
            public DateTime? LimitDate { get; set; }
        }
    }
}