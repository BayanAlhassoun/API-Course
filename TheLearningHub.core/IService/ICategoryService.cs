using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLearningHub.core.Data;

namespace TheLearningHub.core.IService
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategories();

        Task<Category> GetCategoryById(int id);

        Task CreateCategory(Category category);

        Task UpdateCategory(Category category);

        Task DeleteCategory(int id);
    }
}
