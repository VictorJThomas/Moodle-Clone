using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moodle_Clone.Domain.Interfaces;
using static Moodle_Clone.Domain.DTOs.StudentDTO;

namespace Moodle_Clone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost("courses")]
        public async Task<IActionResult> AddCourse([FromBody] AddCourseStudentDTO student)
        {
            try
            {
                await _studentService.AddCourseStudent(student);
                return Ok("Course added to student successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("courses")]
        public async Task<IActionResult> GetCourses([FromQuery] AllCoursesStudentDTO student)
        {
            try
            {
                var courses = await _studentService.AllCourses(student);
                return Ok(courses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("assignments")]
        public async Task<IActionResult> GetAssignments([FromQuery] StudentAssignmentDTO student)
        {
            try
            {
                var assignments = await _studentService.AllAssignments(student);
                return Ok(assignments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
