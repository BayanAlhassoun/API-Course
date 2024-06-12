using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheLearningHub.core.Data;
using TheLearningHub.core.IService;

namespace TheLearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCourseController : ControllerBase
    {
        private readonly IStudent_Course_Service _student_course_service;

        public StudentCourseController(IStudent_Course_Service student_course_service)
        {
            _student_course_service = student_course_service;
        }

        [HttpGet]
        [Route ("Search/{startDate}/{endDate}")]
        public List<Student> Search(DateTime startDate, DateTime endDate)
        {
            return _student_course_service.Search(startDate, endDate);
        }
    }
}
