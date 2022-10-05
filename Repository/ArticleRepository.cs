using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository
{
    public class ArticleRepository : RepositoryBase<Article>, IArticleRepository
    {
        public ArticleRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateArticle(Article article) => Create(article);

        public void DeleteArticle(Article article) => Delete(article);

        public async Task<PagedList<Article>> GetAllArticlesAsync(ArticleParameters articleParameters, bool trackChanges)
        {
            var articles = GetAll(trackChanges)
               .FilterArticles(articleParameters.CreationDateMin, articleParameters.CreationDateMax)
               .Search(articleParameters.SearchTerm)               
               .Sort(articleParameters.OrderBy)
               .Skip((articleParameters.PageNumber - 1) * articleParameters.PageSize)
               .Take(articleParameters.PageSize)
               .ToListAsync()
               .Result;

            var count = await GetAll(trackChanges).CountAsync();

            return new PagedList<Article>(articles, count, articleParameters.PageNumber, articleParameters.PageSize);
        }

        public async Task<Article> GetArticleAsync(Guid articleId, bool trackChanges) => await GetByCondition(x => x.Id.Equals(articleId), trackChanges).SingleOrDefaultAsync();
    }
}
