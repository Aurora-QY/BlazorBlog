using System;
using System.Collections.Generic;

namespace AuroraQY.BlazorBlog.Application.DTOs
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string AuthorName { get; set; }
        public List<CommentDto> Comments { get; set; }
    }
}
