
namespace Shared.DataTransferObjects
{
    public record ArticleDto(Guid Id, string Title, string Description, string Content, string SeoUrl, DateTime CreatedDate, DateTime? UpdatedDate);
}
