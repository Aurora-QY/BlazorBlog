using AuroraQY.BlazorBlog.Application.Interfaces;
using AuroraQY.BlazorBlog.Application.Services;
using AuroraQY.BlazorBlog.Application.Mappings;
using AuroraQY.BlazorBlog.Infrastructure;
using AuroraQY.BlazorBlog.Infrastructure.ExternalServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// builder.Services.AddAutoMapper(typeof(Program).Assembly, typeof(PostService).Assembly);
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
