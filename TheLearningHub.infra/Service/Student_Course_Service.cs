﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLearningHub.core.Data;
using TheLearningHub.core.IRepository;
using TheLearningHub.core.IService;

namespace TheLearningHub.infra.Service
{
    public class Student_Course_Service : IStudent_Course_Service
    {
        private readonly IStudent_Course_Repository _student_Course;

        public Student_Course_Service(IStudent_Course_Repository student_Course)
        {
            _student_Course = student_Course;
        }

        public List<Student> Search(DateTime startDate, DateTime endDate)
        {
         return  _student_Course.Search(startDate, endDate);
        }
    }
}
