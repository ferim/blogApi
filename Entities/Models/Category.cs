using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name is mandatory.")]
        [MaxLength(160, ErrorMessage = "Maximum length for Name is 160 characters.")]
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
        public ICollection<Article>? Articles { get; set; }
        public List<ArticleCategory>? ArticleCategories { get; set; }
    }
}
