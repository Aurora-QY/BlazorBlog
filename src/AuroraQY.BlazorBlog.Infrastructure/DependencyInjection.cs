using AuroraQY.BlazorBlog.Domain.Interfaces;
using AuroraQY.BlazorBlog.Infrastructure.Data;
using AuroraQY.BlazorBlog.Infrastructure.Data.Repositories;
using AuroraQY.BlazorBlog.Infrastructure.ExternalServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuroraQY.BlazorBlog.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            // 使用 PooledDbContextFactory
            services.AddPooledDbContextFactory<BlogDbContext>(
                options =>
                    options.UseMySql(
                        configuration.GetConnectionString("DefaultConnection"),
                        new MySqlServerVersion(new Version(8, 0, 21)),
                        mySqlOptions => mySqlOptions.EnableRetryOnFailure()
                    )
            );

            // services.AddDbContext<BlogDbContext>(
            //     options =>
            //         options.UseMySql(
            //             configuration.GetConnectionString("DefaultConnection"),
            //             new MySqlServerVersion(new Version(8, 0, 21)),
            //             mySqlOptions => mySqlOptions.EnableRetryOnFailure()
            //         )
            // );

            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddSingleton<MarkdownRenderer>();

            return services;
        }
    }
}
