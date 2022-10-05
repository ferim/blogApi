using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class CategoryService : ICategoryService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CategoryService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto category)
        {
            var categoryEntity = _mapper.Map<Category>(category);
            _repository.Category.CreateCategory(categoryEntity);
           
            await _repository.SaveAsync();

            var categoryToReturn = _mapper.Map<CategoryDto>(categoryEntity);

            return categoryToReturn;
        }

        public async Task DeleteCategoryAsync(Guid categoryId, bool trackChanges)
        {
            var category = await GetCategoryAndCheckIfExists(categoryId,trackChanges);

            _repository.Category.DeleteCategory(category);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(bool trackChanges)
        {
            var categories = await _repository.Category.GetAllCategories(trackChanges);

            var categoriesToReturn = _mapper.Map<List<CategoryDto>>(categories);

            return categoriesToReturn;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoriesByArticleAsync(Guid articleId, bool trackChanges)
        {
            var categories = await _repository.Category.GetCategoriesByArticle(articleId, trackChanges);

            var categoriesToReturn = _mapper.Map<List<CategoryDto>>(categories);

            return categoriesToReturn;
        }

        public async Task<CategoryDto> GetCategoryAsync(Guid categoryId, bool trackChanges)
        {
            var category = await GetCategoryAndCheckIfExists(categoryId, trackChanges);

            var categoryToReturn = _mapper.Map<CategoryDto>(category);

            return categoryToReturn;
        }

        public async Task UpdateCategoryAsync(Guid categoryId, UpdateCategoryDto categoryForUpdate, bool trackChanges)
        {
            var category = await GetCategoryAndCheckIfExists(categoryId, trackChanges);

            _mapper.Map(categoryForUpdate, category);
            await _repository.SaveAsync();
        }

        #region Private Methods
        private async Task<Category> GetCategoryAndCheckIfExists(Guid id, bool trackChanges)
        {
            var category = await _repository.Category.GetCategory(id, trackChanges);

            if (category is null)
                throw new CategoryNotFoundException(id);

            return category;
        }
        #endregion
    }
}
