using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository.Configurations;

namespace Repository
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Article>()
            .HasMany(p => p.Categories)
            .WithMany(p => p.Articles)
            .UsingEntity<ArticleCategory>(
                j => j
                    .HasOne(pt => pt.Category)
                    .WithMany(t => t.ArticleCategories)
                    .HasForeignKey(pt => pt.CategoryId),                   

                j => j
                    .HasOne(pt => pt.Article)
                    .WithMany(p => p.ArticleCategories)
                    .HasForeignKey(pt => pt.ArticleId),
                j =>
                {
                    j.HasKey(t => new { t.Id });
                    j.Property(t => t.Id).ValueGeneratedOnAdd();
                });

            modelBuilder.ApplyConfiguration(new ArticleConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ArticleCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
