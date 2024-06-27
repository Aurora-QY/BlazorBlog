using System;

namespace AuroraQY.BlazorBlog.Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public User Author { get; set; }
        public Post Post { get; set; }
    }
}
