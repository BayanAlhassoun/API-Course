using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLearningHub.core.Data;
using TheLearningHub.core.ICommon;
using TheLearningHub.core.IRepository;

namespace TheLearningHub.infra.Repository
{
    public class Student_Course_Repository : IStudent_Course_Repository
    {
        private readonly IDbContext _dbContext;

        public Student_Course_Repository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Student> Search(DateTime startDate, DateTime endDate)
        {
            var p = new DynamicParameters();
            p.Add("DateFrom", startDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("DateTo", endDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Student>("Student_Course_Package.GetInfoByInterval", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
