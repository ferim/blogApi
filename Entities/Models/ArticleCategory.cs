
namespace Entities.Models
{
    public class ArticleCategory
    {
        public int Id { get; set; }
        public Guid ArticleId { get; set; }

        public Article? Article { get; set; }

        public Guid CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}
