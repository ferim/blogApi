using blogApi.ActionFilters;
using blogApi.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace blogApi.Controllers
{
    [Route("api/categories")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class CategoriesController : ControllerBase
    {
        private readonly IServiceManager _service;
        public CategoriesController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _service.CategoryService.GetAllCategoriesAsync(false);

            return Ok(categories);
        }

        [HttpGet()]
        [Route("~/api/articles/{articleId:guid}/categories", Order =-1)]
        public async Task<IActionResult> GetCategoriesForArticle(Guid articleId)
        {
            var categories = await _service.CategoryService.GetCategoriesByArticleAsync(articleId, false);

            return Ok(categories);
        }

        [HttpGet("{id:guid}", Name = "CategoryById")]
        public async Task<IActionResult> GetCategory(Guid categoryId)
        {
            var category = await _service.CategoryService.GetCategoryAsync(categoryId, false);

            return Ok(category);
        }


        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCategory([FromBody][ModelBinder(binderType: typeof(CategoryCreateModelBinder))] CreateCategoryDto category)
        {
            var createdCategory = await _service.CategoryService.CreateCategoryAsync(category);

            return CreatedAtRoute("CategoryById", new { id = createdCategory.Id }, createdCategory);
        }

        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateCategory(Guid id, [FromBody] UpdateCategoryDto category)
        {
            await _service.CategoryService.UpdateCategoryAsync(id, category, true);

            return NoContent();
        }
    }
}
