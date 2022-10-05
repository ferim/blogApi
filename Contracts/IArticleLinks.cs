using Entities.LinkModels;
using Microsoft.AspNetCore.Http;
using Shared.DataTransferObjects;

namespace Contracts
{
    public interface IArticleLinks
    {
        LinkResponse TryGenerateLinks(IEnumerable<ArticleDto> employeesDto, string fields, HttpContext httpContext);
    }
}
