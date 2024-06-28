using AuroraQY.BlazorBlog.Domain.Entities;
using System;

namespace AuroraQY.BlazorBlog.Domain.Services
{
    public class DomainService
    {
        // id等于现在推文作者id才可以编辑
        public bool CanUserEditPost(User user, Post post)
        {
            return user.Id == post.Author.Id;
        }

        // 编辑推文内容
        public void UpdatePostContent(Post post, string newContent)
        {
            post.Content = newContent;
            post.UpdatedAt = DateTime.UtcNow;
        }
    }
}
