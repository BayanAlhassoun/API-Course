using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLearningHub.core.Data;
using TheLearningHub.core.IRepository;
using TheLearningHub.core.IService;

namespace TheLearningHub.infra.Service
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            
            _courseRepository = courseRepository;
        }

        public async Task CreateCourse(Course course)
        {
          await  _courseRepository.CreateCourse(course);
        }

        public async Task DeleteCourse(int id)
        {
           await _courseRepository.DeleteCourse(id);
        }

        public async Task<List<Course>> GetAllCourses()
        {
           return await _courseRepository.GetAllCourses();
        }

        public async Task<Course> GetCourseById(int id)
        {
           //return await _courseRepository.GetCourseById(id);

           var result = await _courseRepository.GetAllCourses();
            var course = result.Where(x => x.Courseid == id).FirstOrDefault();
            return course;
        }

        public async Task UpdateCourse(Course course)
        {
            await _courseRepository.UpdateCourse(course);
        }
    }
}
