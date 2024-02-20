using Microsoft.EntityFrameworkCore;
using Moodle_Clone.Domain.DTOs;
using Moodle_Clone.Domain.Interfaces;
using Moodle_Clone.Infraestructure.Context;
using static Moodle_Clone.Domain.DTOs.StudentDTO;

namespace Moodle_Clone.Infraestructure.Services
{
    public class StudentService : IStudentService
    {
        private readonly DatabaseContext _context;

        public StudentService(DatabaseContext context) 
        {
            _context = context;
        }
        public async Task AddCourseStudent(AddCourseStudentDTO student)
        {
            if (!await _context.Students.AnyAsync(s => s.StudentId == student.StudentId) ||
                !await _context.Courses.AnyAsync(c => c.CourseId == student.CourseId))
            {
                throw new Exception("Invalid Student or Course ID");
            }

            if (_context.Students.Any(s => s.StudentId == student.StudentId &&
                                             s.Course.Any(c => c.CourseId == student.CourseId)))
            {
                throw new Exception("Student already enrolled in this course");
            }

            var course = await _context.Courses.FindAsync(student.CourseId);
            var students = await _context.Students.FindAsync(student.StudentId);

            course.Students.Add(students);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Guid>> AllCourses(AllCoursesStudentDTO student)
        {
            var courses = await _context.Courses
                .Where(c => c.Students.Any(s => s.StudentId == student.StudentId))
                .Select(c => c.CourseId)
                .ToListAsync();

            return courses;
        }

        public async Task<List<Guid>> AllAssignments(StudentAssignmentDTO student)
        {
            var assignments = await _context.Assignments
                .Where(a => a.Course.Students.Any(s => s.StudentId == student.StudentId))
                .Select(a => new StudentAssignmentDTO
                {
                    AssignmentsId = a.AssignmentsId,
                    AssignmentsName = a.AssignmentsName,
                    LimitDate = a.LimitDate
                })
                .ToListAsync();

            return assignments.Select(a => a.AssignmentsId).ToList();
        }      
    }
}
