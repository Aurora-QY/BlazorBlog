using System;
using System.Text.RegularExpressions;

namespace AuroraQY.BlazorBlog.Domain.ValueObjects
{
    public class Email
    {
        private Email() { }

        public string Value { get; private set; }

        public Email(string value)
        {
            if (!IsValid(value))
                throw new ArgumentException("Invalid email format");
            Value = value;
        }

        public static Email Create(string value)
        {
            return new Email(value);
        }

        public static bool IsValid(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }
}
