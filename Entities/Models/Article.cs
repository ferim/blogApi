using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Article
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title is mandatory.")]
        [MaxLength(60, ErrorMessage = "Maximum length for Title is 60 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is mandatory.")]
        [MaxLength(200, ErrorMessage = "Maximum length for Description is 200 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Content is mandatory.")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Seo friendly url is mandatory.")]
        public string SeoUrl { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
        public ICollection<Category>? Categories { get; set; }
        public List<ArticleCategory>? ArticleCategories { get; set; }
    }
}
