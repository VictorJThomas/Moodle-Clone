using Microsoft.EntityFrameworkCore;
using Moodle_Clone.Domain.DTOs;
using Moodle_Clone.Domain.Interfaces;
using Moodle_Clone.Domain.Models;
using Moodle_Clone.Infraestructure.Context;
using static Moodle_Clone.Domain.DTOs.TeacherDTO;

namespace Moodle_Clone.Infraestructure.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly DatabaseContext _context;

        public TeacherService(DatabaseContext context) 
        {
            _context = context;
        }

        public async Task CreateAssignment(PublishAssigmentDTO newAsssignment)
        {
            var assignment = new Assignments
            {
                AssignmentsId = newAsssignment.AssignmentsId,
                TeacherId = newAsssignment.TeacherId,
                AssignmentsName = newAsssignment.AssignmentsName,
                AssignmentsDescription = newAsssignment.AssignmentsDescription,
                LimitDate = (DateTime)newAsssignment.LimitDate,
                AssignmentsStatus = false,
                File = null
            };

            _context.Assignments.Add(assignment);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Guid>> TeacheOnlyCourseDTO(TeacheOnlyCourseDTO teacher)
        {
            var courses = await _context.Courses
                .Where(c => c.TeacherId == teacher.TeacherID)
                .Select(c => c.TeacherId)
                .ToListAsync();

            return courses;
        }

        public async Task<List<Guid>> TeacherCoursesDTO(TeacherCoursesDTO teacherCourses)
        {
            var courses = await _context.Courses
                .Where(c => c.TeacherId == teacherCourses.TeacherId)
                .Select(c => c.CourseId)
                .ToListAsync();

            return courses;
        }
    }
}
