using AuroraQY.BlazorBlog.Domain.Entities;
using System;

namespace AuroraQY.BlazorBlog.Domain.Services
{
    public class DomainService
    {
        public bool CanUserEditPost(User user, Post post)
        {
            return user.Id == post.Author.Id;
        }

        public void UpdatePostContent(Post post, string newContent)
        {
            post.Content = newContent;
            post.UpdatedAt = DateTime.UtcNow;
        }
    }
}
