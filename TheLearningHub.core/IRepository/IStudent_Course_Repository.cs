using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLearningHub.core.Data;

namespace TheLearningHub.core.IRepository
{
    public interface IStudent_Course_Repository
    {
       List<Student> Search(DateTime startDate, DateTime endDate);
    }
}
