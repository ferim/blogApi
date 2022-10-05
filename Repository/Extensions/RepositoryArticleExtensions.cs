using Entities.Models;
using Repository.Extensions.Utility;

namespace Repository.Extensions
{
    public static class RepositoryArticleExtensions
    {
        public static IQueryable<Article> FilterArticles(this IQueryable<Article> articles, DateTime minCreationDate, DateTime maxCreationDate) => 
            articles.Where(x => x.CreatedDate >= minCreationDate && x.CreatedDate <= maxCreationDate);
        public static IQueryable<Article> Search(this IQueryable<Article> articles,
        string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return articles;
            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return articles.Where(x => x.Title.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<Article> Sort(this IQueryable<Article> articles, string
orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return articles.OrderBy(x => x.CreatedDate);
            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Article>(orderByQueryString);
            if (string.IsNullOrWhiteSpace(orderQuery))
                return articles.OrderBy(x => x.CreatedDate);

            return articles.OrderBy(x => orderQuery);
        }
    }
}
