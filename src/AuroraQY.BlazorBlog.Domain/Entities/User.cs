using AuroraQY.BlazorBlog.Domain.ValueObjects;
using System.Collections.Generic;

namespace AuroraQY.BlazorBlog.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public Email? Email { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
