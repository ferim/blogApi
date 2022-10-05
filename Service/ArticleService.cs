using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.LinkModels;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service
{
    internal sealed class ArticleService : IArticleService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IArticleLinks _articleLinks;
        public ArticleService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, IArticleLinks articleLinks)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _articleLinks = articleLinks;
        }

        public async Task<ArticleDto> CreateArticleAsync(CreateArticleDto article)
        {
            var articleEntity = _mapper.Map<Article>(article);

            _repository.Article.CreateArticle(articleEntity);
            if (article.Categories != null)
            {

            
            foreach (var category in article.Categories)
            {
                _repository.ArticleCategory.CreateArticleCategory(new ArticleCategory()
                {
                    ArticleId = articleEntity.Id,
                    CategoryId = new Guid(category)
                });
            }
}
            await _repository.SaveAsync();

            var articleToReturn = _mapper.Map<ArticleDto>(articleEntity);

            return articleToReturn;

        }

        public async Task DeleteArticleAsync(Guid articleId, bool trackChanges)
        {
            var article = await GetArticleAndCheckIfExists(articleId, trackChanges);

            _repository.Article.DeleteArticle(article);
             await _repository.SaveAsync();
        }

        public async Task<(LinkResponse linkResponse, MetaData metaData)> GetAllArticlesAsync(LinkParameters linkParameters, bool trackChanges)
        {
            if (!linkParameters.ArticleParameters.ValidCreationDate)
                throw new UnValidCreationDateBadRequestException();

            var articlesWithMetaData = await _repository.Article.GetAllArticlesAsync(linkParameters.ArticleParameters, trackChanges);

            var articlesDto = _mapper.Map<IEnumerable<ArticleDto>>(articlesWithMetaData);
            var links = _articleLinks.TryGenerateLinks(articlesDto, linkParameters.ArticleParameters.Fields, linkParameters.Context);
            return (links, articlesWithMetaData.MetaData);

        }

        public async Task<ArticleDto> GetArticleAsync(Guid articleId, bool trackChanges)
        {
            var article = await GetArticleAndCheckIfExists(articleId, trackChanges);

            var articleToReturn = _mapper.Map<ArticleDto>(article);

            return articleToReturn;
        }

        public async Task<(UpdateArticleDto articleToPatch, Article articleEntity)> GetArticleForPatchAsync(Guid articleId, bool trackChanges)
        {
            var article = await GetArticleAndCheckIfExists(articleId, trackChanges);            

            var  articleToPatch = _mapper.Map<UpdateArticleDto>(article);

            return (articleToPatch, article);
        }

        public async Task SaveChangesForPatchAsync(UpdateArticleDto articleToPatch, Article articleEntity)
        {
           _mapper.Map(articleToPatch, articleEntity);
            await _repository.SaveAsync();
        }

        public async Task UpdateArticleAsync(Guid articleId, UpdateArticleDto updateArticle, bool trackChanges)
        {
            var article = await GetArticleAndCheckIfExists(articleId, trackChanges);            

            _mapper.Map(updateArticle, article);
            await _repository.SaveAsync();
        }

        #region Private Methods
        private async Task<Article> GetArticleAndCheckIfExists(Guid id,bool trackChanges) 
        {
            var article = await _repository.Article.GetArticleAsync(id, trackChanges);

            if (article is null)
                throw new ArticleNotFoundException(id);

            return article;
        }
        #endregion
    }
}
