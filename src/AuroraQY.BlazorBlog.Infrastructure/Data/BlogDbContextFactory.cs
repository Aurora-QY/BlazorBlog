using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.IO;

namespace AuroraQY.BlazorBlog.Infrastructure.Data
{
    public class BlogDbContextFactory : IDesignTimeDbContextFactory<BlogDbContext>
    {
        public BlogDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<BlogDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 21)));

            return new BlogDbContext(builder.Options);
        }
    }
}
