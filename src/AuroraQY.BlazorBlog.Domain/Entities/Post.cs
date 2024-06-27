using System;
using System.Collections.Generic;

namespace AuroraQY.BlazorBlog.Domain.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Summary { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int AuthorId { get; set; } // 添加这行
        public User Author { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
