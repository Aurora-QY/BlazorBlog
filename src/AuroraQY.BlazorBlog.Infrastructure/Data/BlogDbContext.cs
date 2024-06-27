using AuroraQY.BlazorBlog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuroraQY.BlazorBlog.Infrastructure.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options)
            : base(options) { }

        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().OwnsOne(u => u.Email);

            modelBuilder
                .Entity<Post>()
                .HasMany(p => p.Comments)
                .WithOne(c => c.Post)
                .HasForeignKey("PostId");

            modelBuilder
                .Entity<User>()
                .HasMany(u => u.Posts)
                .WithOne(p => p.Author)
                .HasForeignKey("AuthorId");
        }
    }
}
