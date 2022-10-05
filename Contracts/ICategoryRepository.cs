using Entities.Models;

namespace Contracts
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategories(bool trackChanges);
        Task<Category> GetCategory(Guid categoryId, bool trackChanges);
        Task<IEnumerable<Category>> GetCategoriesByArticle(Guid articleId, bool trackChanges);
        void CreateCategory(Category category);
        void DeleteCategory(Category category);
        void UpdateCategory(Category category);
    }
}
