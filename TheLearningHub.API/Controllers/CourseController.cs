using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheLearningHub.core.Data;
using TheLearningHub.core.IService;

namespace TheLearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<List<Course>> GetAllCourses() // MVC: hostname/port/Course/GetAllCourses // API: hostname/port/API/Course
        {
           return await _courseService.GetAllCourses();
        }

        [HttpPost]
        public async Task CreateCourse([FromBody] Course course)
        {
            await _courseService.CreateCourse(course);
        }

        [HttpPut]
        public async Task UpdateCourse(Course course)
        {
            await _courseService.UpdateCourse(course);
        }

        [HttpDelete ("{id}")] // hostname/port/api/course/1
        public async Task DeleteCourse(int id)
        {
            await _courseService.DeleteCourse(id);
        }

        [HttpGet]
        [Route ("GetById/{id}")]
        public async Task<Course> GetCourseById(int id) // API: hostname/port/API/Course/GetById/X
        {
           return await _courseService.GetCourseById(id);
        }

    }
}
