using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public abstract record ArticleForManipulationDto
    {
        [Required(ErrorMessage = "Title is mandatory.")]
        [MaxLength(60, ErrorMessage = "Maximum length for Title is 60 characters.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is mandatory.")]
        [MaxLength(200, ErrorMessage = "Maximum length for Description is 200 characters.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Content is mandatory.")]
        public string Content { get; set; }
        public string[]? Categories { get; set; }
    }
}
