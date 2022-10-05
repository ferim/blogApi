using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    public class ArticleCategoryConfiguration : IEntityTypeConfiguration<ArticleCategory>
    {
        public void Configure(EntityTypeBuilder<ArticleCategory> builder)
        {
            builder.HasData(
                new ArticleCategory
                {
                    Id = 1,
                    ArticleId = new Guid("2c90cdb6-910b-4f9a-a0b9-de2e88c79de0"),
                    CategoryId = new Guid("4cc2f0ce-9e1a-46e3-a2b0-d75a275a6aec")
                },
                new ArticleCategory
                {
                    Id = 2,
                    ArticleId = new Guid("2c90cdb6-910b-4f9a-a0b9-de2e88c79de0"),
                    CategoryId = new Guid("a522488a-931f-4424-946f-213dd65ea1b3")
                }
                );
        }
    }
}

