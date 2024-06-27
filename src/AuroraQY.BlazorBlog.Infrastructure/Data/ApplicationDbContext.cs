using Microsoft.EntityFrameworkCore;
using AuroraQY.BlazorBlog.Domain.Entities;

namespace AuroraQY.BlazorBlog.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<BlogPost> BlogPosts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 可以在这里添加额外的模型配置
        }
    }
}
