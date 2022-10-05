using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category
                {
                    Id = new Guid("4cc2f0ce-9e1a-46e3-a2b0-d75a275a6aec"),
                    Name = "Dotnet Core"
                },
                new Category
                {
                    Id = new Guid("a522488a-931f-4424-946f-213dd65ea1b3"),
                    Name = "Dotnet Framework"
                }
                );
        }
    }
}
