using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts
{
    public interface IArticleRepository
    {
        Task<PagedList<Article>> GetAllArticlesAsync(ArticleParameters articleParameters, bool trackChanges);
        Task<Article> GetArticleAsync(Guid articleId, bool trackChanges);
        void CreateArticle(Article article);
        void DeleteArticle(Article article);
    }
}
