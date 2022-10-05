using blogApi.ActionFilters;
using blogApi.ModelBinders;
using Entities.LinkModels;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System.Text.Json;

namespace blogApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/articles")]
    [ApiController]
    //[ResponseCache(CacheProfileName = "10MinutesDuration")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class ArticlesController : ControllerBase
    {
        private readonly IServiceManager _service;

        public ArticlesController(IServiceManager service) => _service = service;
        
        [HttpOptions]
        public IActionResult GetArticlesOptions()
        {
            Response.Headers.Add("Allow", "GET, OPTIONS, POST, PUT, PATCH");
            return Ok();
        }

        [HttpGet(Name = "GetArticles")]
        [HttpHead]
        [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
        public async Task<IActionResult> GetArticles([FromQuery] ArticleParameters articleParameters)
        {
            var linkParams = new LinkParameters(articleParameters, HttpContext);
          
            var result = await _service.ArticleService.GetAllArticlesAsync(linkParams, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.metaData));

            return result.linkResponse.HasLinks 
                ? Ok(result.linkResponse.LinkedEntities) 
                : Ok(result.linkResponse.ShapedEntities);
        }

        [HttpGet("{id:guid}", Name ="ArticleById")]
        [HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge = 600)]
        [HttpCacheValidation(MustRevalidate = false)]
        public async Task<IActionResult> GetArticle(Guid id)
        {
            var company = await _service.ArticleService.GetArticleAsync(id, trackChanges: false);
            return Ok(company);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes ="Bearer")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateArticle([FromBody][ModelBinder(binderType: typeof(ArticleCreateModelBinder))] CreateArticleDto article)
        {
            var createdArticle = await _service.ArticleService.CreateArticleAsync(article);

            return CreatedAtRoute("ArticleById", new { id = createdArticle.Id }, createdArticle);
        }

        [HttpPut("{id:guid}")]
        [Authorize]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateArticle(Guid id, [FromBody][ModelBinder(binderType: typeof(ArticleUpdateModelBinder))] UpdateArticleDto article)
        {            
            await _service.ArticleService.UpdateArticleAsync(id, article, true);
            
            return NoContent();
        }

        [HttpPatch("id:guid")]
        [Authorize]
        public async Task<IActionResult> PatchArticle(Guid id, [FromBody]JsonPatchDocument<UpdateArticleDto> patchDocument) 
        {
            if (patchDocument is null)
                return BadRequest("patchDocument object is null.");

            var result = await _service.ArticleService.GetArticleForPatchAsync(id, true);

            patchDocument.ApplyTo(result.articleToPatch);
            
            TryValidateModel(result.articleToPatch);
            
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _service.ArticleService.SaveChangesForPatchAsync(result.articleToPatch, result.articleEntity);

            return NoContent();
        }
    }
}
