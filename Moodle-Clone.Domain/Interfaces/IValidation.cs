using System.ComponentModel.DataAnnotations;

namespace Moodle_Clone.Domain.Interfaces
{
    public interface IValidation
    {
        Task<ValidationResult> ValidateAsync<T>(T entity);

        Task<bool> ValidateEmailExistAsync(string email);

        Task<bool> ValidateUserExistAsync(int userId);

        Task<bool> ValidateStudentExistAsync(int studentId);

        Task<bool> ValidateTeacherExistAsync(int teacherId);

        Task<bool> ValidateTeacherSubjectExistAsync(int professorId, int subjectId);

        Task<bool> ValidateStudentSubjectExistAsync(int studentId, int subjectId);

    }
}
