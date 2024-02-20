using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moodle_Clone.Domain.Interfaces;
using static Moodle_Clone.Domain.DTOs.TeacherDTO;

namespace Moodle_Clone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpPost("assignments")]
        public async Task<IActionResult> CreateAssignment([FromBody] PublishAssigmentDTO newAssignment)
        {
            try
            {
                await _teacherService.CreateAssignment(newAssignment);
                return Ok("Assignment created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("course")]
        public async Task<IActionResult> GetTeacherOnlyCourses([FromQuery] TeacheOnlyCourseDTO teacher)
        {
            try
            {
                var courses = await _teacherService.TeacheOnlyCourseDTO(teacher);
                return Ok(courses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("courses")]
        public async Task<IActionResult> GetTeacherCourses([FromQuery] TeacherCoursesDTO teacherCourses)
        {
            try
            {
                var courses = await _teacherService.TeacherCoursesDTO(teacherCourses);
                return Ok(courses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
