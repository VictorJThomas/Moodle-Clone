using static Moodle_Clone.Domain.DTOs.StudentDTO;

namespace Moodle_Clone.Domain.Interfaces
{
    public interface IStudentService
    {
        Task AddCourseStudent(AddCourseStudentDTO student);

        Task<List<Guid>> AllCourses(AllCoursesStudentDTO student);

        Task<List<Guid>> AllAssignments(StudentAssignmentDTO student);

    }
}
