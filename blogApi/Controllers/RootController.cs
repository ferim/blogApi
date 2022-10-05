using Entities.LinkModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace blogApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class RootController : ControllerBase
    {
        private readonly LinkGenerator _linkGenerator;
        public RootController(LinkGenerator linkGenerator) => _linkGenerator = linkGenerator;

        [HttpGet(Name = "GetRoot")]
        public IActionResult GetRoot([FromHeader(Name = "Accept")] string mediaType)
        {
            if (mediaType.Contains("application/vnd.fatihblog.apiroot"))
            {
                var list = new List<Link>
                    {
                        new Link
                        {
                            Href = _linkGenerator.GetUriByName(HttpContext, nameof(GetRoot), new {}),
                            Rel = "self",
                            Method = "GET"
                        },
                        new Link
                        {
                            Href = _linkGenerator.GetUriByName(HttpContext, "GetArticles", new {}),
                            Rel = "articles",
                            Method = "GET"
                        },
                        new Link                        
                        {
                            Href = _linkGenerator.GetUriByName(HttpContext, "CreateArticle", new {}),
                            Rel = "create_article",
                            Method = "POST"
                        }
                    };
                return Ok(list);
            }
            return NoContent();
        }
    }
}
