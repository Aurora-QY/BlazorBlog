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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.OwnsOne(u => u.Email);
                entity
                    .HasMany(u => u.Posts)
                    .WithOne(p => p.Author)
                    .HasForeignKey(p => p.AuthorId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity
                    .HasMany(p => p.Comments)
                    .WithOne(c => c.Post)
                    .HasForeignKey("PostId")
                    .OnDelete(DeleteBehavior.Cascade);

                entity
                    .HasOne(p => p.Author)
                    .WithMany(u => u.Posts)
                    .HasForeignKey(p => p.AuthorId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity
                    .HasOne(c => c.Post)
                    .WithMany(p => p.Comments)
                    .HasForeignKey("PostId")
                    .OnDelete(DeleteBehavior.Cascade);

                entity
                    .HasOne(c => c.Author)
                    .WithMany()
                    .HasForeignKey("AuthorId")
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
