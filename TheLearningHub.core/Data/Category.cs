﻿using System;
using System.Collections.Generic;

namespace TheLearningHub.core.Data
{
    public partial class Category
    {
        public Category()
        {
            Courses = new HashSet<Course>();
        }

        public decimal Categoryid { get; set; }
        public string? Categoryname { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
