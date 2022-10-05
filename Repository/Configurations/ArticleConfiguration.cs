using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasData(
                new Article
                {
                    Id = new Guid("2c90cdb6-910b-4f9a-a0b9-de2e88c79de0"),
                    Title = "First Blog Post",
                    Description = "This is the first blog post",
                    Content = "Lorem ipsum dolor sit amet.",
                    SeoUrl = "first-blog-post"
                },
                new Article
                {
                    Id = new Guid("9c24f5f5-23f5-40f0-8452-db9445700895"),
                    Title = "Second Blog Post",
                    Description = "This is the second blog post",
                    Content = "Lorem ipsum dolor sit amet 2.",
                    SeoUrl = "second-blog-post"
                }
                );
        }
    }
}
