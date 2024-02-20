using static Moodle_Clone.Domain.DTOs.TeacherDTO;

namespace Moodle_Clone.Domain.Interfaces
{
    public interface ITeacherService
    {
        Task<List<Guid>> TeacherCoursesDTO(TeacherCoursesDTO teacherCourses);

        Task<List<Guid>> TeacheOnlyCourseDTO(TeacheOnlyCourseDTO teacher);

        Task CreateAssignment(PublishAssigmentDTO newAsssignment);
    }
}
