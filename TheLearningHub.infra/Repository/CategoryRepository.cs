﻿using Dapper;
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
    public class CategoryRepository : ICategoryRepository
    {

        private readonly IDbContext _dbContext ;

        public CategoryRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateCategory(Category category)
        {
            var param = new DynamicParameters();
            param.Add("category_name", category.Categoryname, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.ExecuteAsync("Category_Package.CreateCategory", param, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteCategory(int id)
        {
            var param = new DynamicParameters();
            param.Add("category_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.ExecuteAsync("Category_Package.DeleteCategory", param, commandType: CommandType.StoredProcedure);
        } 

        public async Task<List<Category>> GetAllCategories()
        {
            var result = await _dbContext.Connection.QueryAsync<Category, Course, Category>("Category_Package.GetAllCategories", (category, course) => {
                category.Courses.Add(course);
                return category;

            },
            splitOn: "courseid",
                commandType: CommandType.StoredProcedure); 
            return result.ToList();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var param = new DynamicParameters();
            param.Add("Category_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Category>("Category_Package.GetCategoryById", param, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task UpdateCategory(Category category)
        {
            var param = new DynamicParameters();
            param.Add("category_id", category.Categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("new_name", category.Categoryname, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.ExecuteAsync("Category_Package.Update_Category", param, commandType: CommandType.StoredProcedure);
        }
    }
}
