using System;
using System.ComponentModel.DataAnnotations;

namespace AuroraQY.BlazorBlog.Application.DTOs
{
    public class PostDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "请输入标题")]
        [StringLength(100, ErrorMessage = "标题不能超过100个字符")]
        public string Title { get; set; }

        [Required(ErrorMessage = "请输入内容")]
        public string Content { get; set; }

        [StringLength(200, ErrorMessage = "摘要不能超过200个字符")]
        public string Summary { get; set; }

        public string ImageUrl { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string AuthorName { get; set; }

        public int AuthorId { get; set; }

        // 默认构造函数
        public PostDto()
        {
            AuthorName = "AuroraQY";
            AuthorId = 1;
        }
    }
}
