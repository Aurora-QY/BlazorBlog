using System;
using System.Collections.Generic;

namespace AuroraQY.BlazorBlog.Domain.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public User Author { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
