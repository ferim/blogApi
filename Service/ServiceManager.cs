using AutoMapper;
using Contracts;
using Entities.ConfigurationModels;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IArticleService> _articleService;
        private readonly Lazy<ICategoryService> _categoryService;
        private readonly Lazy<IAuthenticationService> _authenticationService;
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper, IArticleLinks articleLinks, UserManager<User> userManager, IOptionsMonitor<JwtConfiguration> configuration)
        {
            _articleService = new Lazy<IArticleService>(() => new ArticleService(repositoryManager, loggerManager, mapper, articleLinks));
            _categoryService = new Lazy<ICategoryService>(() => new CategoryService(repositoryManager, loggerManager, mapper));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(loggerManager, mapper,userManager,configuration));
        }

        public IArticleService ArticleService => _articleService.Value;

        public ICategoryService CategoryService => _categoryService.Value;
        public IAuthenticationService AuthenticationService => _authenticationService.Value;

    }
}
