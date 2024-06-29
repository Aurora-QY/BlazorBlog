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
        private readonly IDbContextFactory<BlogDbContext> _contextFactory;

        public PostRepository(IDbContextFactory<BlogDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        // 之前是所有查询共用context

        // public async Task<Post> GetByIdAsync(int id)
        // {
        //     return await _context.Posts
        //         .Include(p => p.Author)
        //         .Include(p => p.Comments)
        //         .ThenInclude(c => c.Author)
        //         .FirstOrDefaultAsync(p => p.Id == id);
        // }

        // 获取id对应推文
        public async Task<Post> GetByIdAsync(int id)
        {
            using var _context = await _contextFactory.CreateDbContextAsync();
            return await _context.Posts
                .Include(p => p.Author)
                .Include(p => p.Comments)
                .ThenInclude(c => c.Author)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        // 降序就是获取最新的
        public async Task<IEnumerable<Post>> GetLatestPostsAsync(int count)
        {
            using var _context = await _contextFactory.CreateDbContextAsync();
            return await _context.Posts
                .OrderByDescending(p => p.CreatedAt)
                .Take(count)
                .Include(p => p.Author)
                .ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            using var _context = await _contextFactory.CreateDbContextAsync();
            return await _context.Posts.Include(p => p.Author).ToListAsync();
        }

        public async Task AddAsync(Post post)
        {
            using var _context = await _contextFactory.CreateDbContextAsync();
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Post post)
        {
            using var _context = await _contextFactory.CreateDbContextAsync();
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            using var _context = await _contextFactory.CreateDbContextAsync();
            var post = await _context.Posts.FindAsync(id);
            if (post != null)
            {
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
            }
        }
    }
}
