using System;
using System.Collections.Generic;

namespace TheLearningHub.core.Data
{
    public partial class Course
    {
        public Course()
        {
            StdCourses = new HashSet<StdCourse>();
        }

        public decimal Courseid { get; set; }
        public string? Coursename { get; set; }
        public decimal? Categoryid { get; set; }
        public string? Imagename { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ICollection<StdCourse> StdCourses { get; set; }
    }
}
