using Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IArticleRepository> _articleRepository;
        private readonly Lazy<ICategoryRepository> _categoryRepository;
        private readonly Lazy<IArticleCategoryRepository> _articleCategoryRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _articleRepository = new Lazy<IArticleRepository>(() => new ArticleRepository(repositoryContext));
            _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(repositoryContext));
            _articleCategoryRepository = new Lazy<IArticleCategoryRepository>(() => new ArticleCategoryRepository(repositoryContext));
        }

        public IArticleRepository Article => _articleRepository.Value;

        public ICategoryRepository Category => _categoryRepository.Value;
        public IArticleCategoryRepository ArticleCategory => _articleCategoryRepository.Value;
        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
        public void ClearTrackingData() => _repositoryContext.ChangeTracker.Clear();
        public void DetachedEntity(object entity) => _repositoryContext.Entry(entity).State = EntityState.Detached;
    }
}
