using Contracts;
using Entities.LinkModels;
using Entities.Models;
using Microsoft.Net.Http.Headers;
using Shared.DataTransferObjects;


namespace blogApi.Utility
{
    public class ArticleLinks : IArticleLinks
    {
        private readonly LinkGenerator _linkGenerator;
        private readonly IDataShaper<ArticleDto> _dataShaper;
        public ArticleLinks(LinkGenerator linkGenerator, IDataShaper<ArticleDto>
        dataShaper)
        {
            _linkGenerator = linkGenerator;
            _dataShaper = dataShaper;
        }
        public LinkResponse TryGenerateLinks(IEnumerable<ArticleDto> articlesDto, string fields, HttpContext httpContext)
        {
            var shapedArticles = ShapeData(articlesDto, fields);
            if (ShouldGenerateLinks(httpContext))
                return ReturnLinkdedArticles(articlesDto, fields, httpContext, shapedArticles);
            return ReturnShapedArticles(shapedArticles);
        }

        private List<Entity> ShapeData(IEnumerable<ArticleDto> articlesDto, string fields) =>
            _dataShaper.ShapeData(articlesDto, fields)
            .Select(e => e.Entity)
            .ToList();

        private bool ShouldGenerateLinks(HttpContext httpContext)
        {
            var mediaType = (MediaTypeHeaderValue)httpContext.Items["AcceptHeaderMediaType"];
            return mediaType.SubTypeWithoutSuffix.EndsWith("hateoas",
            StringComparison.InvariantCultureIgnoreCase);
        }
        private LinkResponse ReturnShapedArticles(List<Entity> shapedArticles) =>
        new LinkResponse { ShapedEntities = shapedArticles };

        private LinkResponse ReturnLinkdedArticles(IEnumerable<ArticleDto> articlesDto,
string fields, HttpContext httpContext, List<Entity> shapedArticles)
        {
            var articleDtoList = articlesDto.ToList();
            for (var index = 0; index < articleDtoList.Count(); index++)
            {
                var articleLinks = CreateLinksForArticle(httpContext, articleDtoList[index].Id, fields);
                shapedArticles[index].Add("Links", articleLinks);
            }
            var articleCollection = new LinkCollectionWrapper<Entity>(shapedArticles);
            var linkedArticles = CreateLinksForArticles(httpContext, articleCollection);
            return new LinkResponse { HasLinks = true, LinkedEntities = linkedArticles };
        }
        private List<Link> CreateLinksForArticle(HttpContext httpContext, Guid id, string fields = "")
        {
            var links = new List<Link>
                    {
                        new Link(_linkGenerator.GetUriByAction(httpContext, "GetArticle",
                        values: new {  id, fields }),
                        "self",
                        "GET"),
                        new Link(_linkGenerator.GetUriByAction(httpContext,
                        "DeleteArticle", values: new { id }),
                        "delete_article",
                        "DELETE"),
                        new Link(_linkGenerator.GetUriByAction(httpContext,
                        "UpdateArticle", values: new { id }),
                        "update_article",
                        "PUT"),
                        new Link(_linkGenerator.GetUriByAction(httpContext,
                        "PartiallyUpdateArticle", values: new { id }),
                        "partially_update_article",
                        "PATCH")
                    };
            return links;
        }
        private LinkCollectionWrapper<Entity> CreateLinksForArticles(HttpContext httpContext,
LinkCollectionWrapper<Entity> articlesWrapper)
        {
            articlesWrapper.Links.Add(new Link(_linkGenerator.GetUriByAction(httpContext,
            "GetArticlesForCatgeory", values: new { }),
            "self",
            "GET"));
            return articlesWrapper;
        }
    }
}


