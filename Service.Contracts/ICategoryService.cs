using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(bool trackChanges);
        Task<IEnumerable<CategoryDto>> GetCategoriesByArticleAsync(Guid articleId, bool trackChanges);
        Task<CategoryDto> GetCategoryAsync(Guid categoryId, bool trackChanges);
        Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto category);

        Task DeleteCategoryAsync(Guid categoryId, bool trackChanges);
        Task UpdateCategoryAsync(Guid categoryId, UpdateCategoryDto category, bool trackChanges);
    }
}
