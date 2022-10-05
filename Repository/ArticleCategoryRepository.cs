using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ArticleCategoryRepository : RepositoryBase<ArticleCategory>, IArticleCategoryRepository
    {
        public ArticleCategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateArticleCategory(ArticleCategory articleCategory) => Create(articleCategory);

        public void DeleteArticleCategory(ArticleCategory articleCategory) => Delete(articleCategory);

        public async Task<IEnumerable<ArticleCategory>> GetArticleCategoryList(Guid articleId, bool trackChanges) => GetAll(trackChanges).Where(x => x.ArticleId == articleId).ToListAsync().Result;
    }
}
