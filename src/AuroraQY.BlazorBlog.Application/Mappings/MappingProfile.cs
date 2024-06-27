using AutoMapper;
using AuroraQY.BlazorBlog.Application.DTOs;
using AuroraQY.BlazorBlog.Domain.Entities;

namespace AuroraQY.BlazorBlog.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Post, PostDto>()
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Username));
            CreateMap<PostDto, Post>();

            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Value));
            CreateMap<UserDto, User>();

            CreateMap<Comment, CommentDto>()
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Username));
            CreateMap<CommentDto, Comment>();
        }
    }
}