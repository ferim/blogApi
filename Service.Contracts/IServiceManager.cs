
namespace Service.Contracts
{
    public interface IServiceManager
    {
        IArticleService ArticleService { get; }
        ICategoryService CategoryService { get; }
        IAuthenticationService AuthenticationService { get; }
    }
}
