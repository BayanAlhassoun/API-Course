﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLearningHub.core.Data;

namespace TheLearningHub.core.IService
{
    public interface ICourseService
    {
        Task<List<Course>> GetAllCourses();
        Task<Course> GetCourseById(int id);

        Task<int> CreateCourse(Course course);

        Task UpdateCourse(Course course);

        Task<int> DeleteCourse(int id);
    }
}
