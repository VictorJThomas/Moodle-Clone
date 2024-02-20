namespace Moodle_Clone.Domain.DTOs
{
    public class StudentDTO
    {
        public class AddCourseStudentDTO
        {
            public Guid StudentId { get; set; }
            public Guid CourseId { get; set; }
        }

        public class StudentAssignmentDTO
        {
            public Guid StudentId { get; set; }

            public Guid AssignmentsId { get; set; }
            public string AssignmentsName { get; set; }
            public DateTime LimitDate { get; set; }
        }


        public class AllCoursesStudentDTO
        {
            public Guid StudentId { get; set; }
        }
    }
}
