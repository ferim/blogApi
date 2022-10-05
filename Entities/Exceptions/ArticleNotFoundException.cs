
namespace Entities.Exceptions
{
    public sealed class ArticleNotFoundException : NotFoundException
    {
        public ArticleNotFoundException(Guid articleId) : base($"The Article (id:{articleId}) not exist in the database.")
        {

        }
    }
}
