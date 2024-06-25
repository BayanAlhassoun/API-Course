using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLearningHub.core.Data;

namespace TheLearningHub.core.IRepository
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllCourses();
        Task<Course> GetCourseById(int id);

        Task<int> CreateCourse(Course course);

        Task UpdateCourse(Course course);

        Task DeleteCourse(int id);

    }
}
