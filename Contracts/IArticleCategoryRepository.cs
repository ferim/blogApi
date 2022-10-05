using Entities.Models;

namespace Contracts
{
    public interface IArticleCategoryRepository
    {
        Task<IEnumerable<ArticleCategory>> GetArticleCategoryList(Guid articleId, bool trackChanges);
        void CreateArticleCategory(ArticleCategory articleCategory);
        void DeleteArticleCategory(ArticleCategory articleCategory);
    }
}
