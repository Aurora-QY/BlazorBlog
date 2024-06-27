using System;
using System.Collections.Generic;

namespace AuroraQY.BlazorBlog.Application.DTOs
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public string AuthorName { get; set; }
    }
}
