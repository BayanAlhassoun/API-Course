using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLearningHub.core.Data;
using TheLearningHub.core.ICommon;
using TheLearningHub.core.IRepository;
using TheLearningHub.infra.Common;

namespace TheLearningHub.infra.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly IDbContext _dbContext;

        public CourseRepository(IDbContext dbContext) // IDbContext DbContext = new DbContext();
        {
            _dbContext = dbContext; // _dbContext = new DbContext()
        }

        public async Task CreateCourse(Course course)
        {
            var param = new DynamicParameters();
            param.Add("course_name", course.Coursename, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("category_id", course.Categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("Image_name", course.Imagename, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.ExecuteAsync("Course_Package.CreateCourse" , param, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteCourse(int id)
        {
            var param = new DynamicParameters();
            param.Add("Course_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.ExecuteAsync("Course_Package.DeleteCourse", param, commandType: CommandType.StoredProcedure);
        }
        public async Task<List<Course>> GetAllCourses()
        {
            var result = await _dbContext.Connection.QueryAsync<Course>("Course_Package.GetAllCourses", commandType: CommandType.StoredProcedure);      
            return result.ToList();
        }

        public async Task<Course> GetCourseById(int id)
        {
            var param = new DynamicParameters();
            param.Add("course_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Course>("Course_Package.GetCourseById", param, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task UpdateCourse(Course course)
        {
            var param = new DynamicParameters();
            param.Add("course_id", course.Courseid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("new_course_name", course.Coursename, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("new_category_id", course.Categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("new_image_name", course.Imagename, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.ExecuteAsync("Course_Package.UpdateCourse", param, commandType: CommandType.StoredProcedure);
        }
    }
}
