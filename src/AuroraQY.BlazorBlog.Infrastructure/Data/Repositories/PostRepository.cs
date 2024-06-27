using AuroraQY.BlazorBlog.Domain.Entities;
using AuroraQY.BlazorBlog.Domain.Interfaces;
using AuroraQY.BlazorBlog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuroraQY.BlazorBlog.Infrastructure.Data.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly BlogDbContext _context;

        public PostRepository(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<Post> GetByIdAsync(int id)
        {
            return await _context.Posts
                .Include(p => p.Author)
                .Include(p => p.Comments)
                .ThenInclude(c => c.Author)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        // 降序就是获取最新的
        public async Task<IEnumerable<Post>> GetLatestPostsAsync(int count)
        {
            return await _context.Posts
                .OrderByDescending(p => p.CreatedAt)
                .Take(count)
                .Include(p => p.Author)
                .ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await _context.Posts.Include(p => p.Author).ToListAsync();
        }

        public async Task AddAsync(Post post)
        {
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Post post)
        {
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post != null)
            {
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
            }
        }
    }
}
