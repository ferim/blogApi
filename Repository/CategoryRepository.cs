using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateCategory(Category category) => Create(category);
        public void DeleteCategory(Category category) => Delete(category);
        public void UpdateCategory(Category category) => Update(category);
        public async Task<IEnumerable<Category>> GetAllCategories(bool trackChanges) =>  GetAll(trackChanges).OrderBy(x => x.Name).ToListAsync().Result;

        public async Task<IEnumerable<Category>> GetCategoriesByArticle(Guid articleId, bool trackChanges) =>await GetByCondition(x => x.Articles.Any(c => c.Id.Equals(articleId)), trackChanges).ToListAsync();

        public async Task<Category> GetCategory(Guid categoryId, bool trackChanges) => await GetByCondition(x => x.Id.Equals(categoryId), trackChanges).SingleOrDefaultAsync();

    }
}
