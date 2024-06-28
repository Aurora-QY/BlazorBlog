using AuroraQY.BlazorBlog.Application.Interfaces;
using AuroraQY.BlazorBlog.Application.Services;
using AuroraQY.BlazorBlog.Application.Mappings;
using AuroraQY.BlazorBlog.Infrastructure;
using AuroraQY.BlazorBlog.Infrastructure.ExternalServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using AuroraQY.BlazorBlog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AuroraQY.BlazorBlog.Domain.Interfaces;
using AuroraQY.BlazorBlog.Infrastructure.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// var config = new MapperConfiguration(cfg =>
// {
//     cfg.AddProfile<MappingProfile>();
// });
// config.AssertConfigurationIsValid();

// builder.Services.AddDbContext<BlogDbContext>(
//     options =>
//         options.UseMySql(
//             builder.Configuration.GetConnectionString("DefaultConnection"),
//             new MySqlServerVersion(new Version(8, 0, 21))
//         )
// );

// 使用 PooledDbContextFactory
builder.Services.AddPooledDbContextFactory<BlogDbContext>(
    options =>
        options.UseMySql(
            builder.Configuration.GetConnectionString("DefaultConnection"),
            new MySqlServerVersion(new Version(8, 0, 21)),
            mySqlOptions => mySqlOptions.EnableRetryOnFailure()
        )
);

// 注册 Repository 和 Service
builder.Services.AddScoped<IPostRepository>(
    sp => new PostRepository(sp.GetRequiredService<IDbContextFactory<BlogDbContext>>())
);
builder.Services.AddScoped<IPostService, PostService>();

builder.Services.AddAutoMapper(typeof(Program).Assembly, typeof(PostService).Assembly);
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddSingleton<MarkdownRenderer>();

// builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
