using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheLearningHub.core.Data;
using TheLearningHub.core.IService;

namespace TheLearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        public async Task<List<Category>> GetAllCategories()
        {
            return await _categoryService.GetAllCategories();
        }
    }
}
