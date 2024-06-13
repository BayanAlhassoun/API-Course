using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLearningHub.core.Data;
using TheLearningHub.core.DTO;

namespace TheLearningHub.core.IRepository
{
    public interface IStudent_Course_Repository
    {
       List<SearchResult> Search(DateTime startDate, DateTime endDate);

        List<StudentsMark> get_top_students_by_grades(int numberOfStudents);
    }
}
