using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        [CheckClaims ("RoleId", "2")]
        public async Task<List<Course>> GetAllCourses() // MVC: hostname/port/Course/GetAllCourses // API: hostname/port/API/Course => Get
        {
           return await _courseService.GetAllCourses();
        }

        [HttpPost]
        public async Task<int> CreateCourse([FromBody] Course course)
        {
           return await _courseService.CreateCourse(course);
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
        [CheckClaims("RoleId", "1")]

        public async Task<Course> GetCourseById(int id) // API: hostname/port/API/Course/GetById/X
        {
           return await _courseService.GetCourseById(id);
        }

        [HttpPost]
        [Route("UploadImage")]
        public string UploadImage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("C:\\Users\\b.alhassoun.ext\\source\\repos\\TheLearningHub.API\\TheLearningHub.API\\Images\\", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create ))
            {
                file.CopyTo(stream);
            }

            return fileName;
        }

    }
}

