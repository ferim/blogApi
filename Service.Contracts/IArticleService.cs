using Entities.LinkModels;
using Entities.Models;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service.Contracts
{
    public interface IArticleService
    {
        Task<(LinkResponse linkResponse , MetaData metaData)> GetAllArticlesAsync(LinkParameters linkParameters, bool trackChanges);
        Task<ArticleDto> GetArticleAsync(Guid articleId, bool trackChanges);
        Task<ArticleDto> CreateArticleAsync(CreateArticleDto article);
        Task DeleteArticleAsync(Guid articleId, bool trackChanges);
        Task UpdateArticleAsync(Guid articleId, UpdateArticleDto article, bool trackChanges);
        Task<(UpdateArticleDto articleToPatch, Article articleEntity)> GetArticleForPatchAsync(Guid articleId, bool trackChanges);
        Task SaveChangesForPatchAsync(UpdateArticleDto articleToPatch, Article articleEntity);
    }
}
