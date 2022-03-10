using AutoMapper;
using Instagram.Helpers;
using Instagram.HttpMessages.Dtos;
using Instagram.HttpMessages.Requests;
using Instagram.HttpMessages.Responses;
using Instagram.Models;
using System;

namespace Instagram.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMapFromImagePostToImagePostDto();
            CreateMapFromPostToPostDto();
            CreateMapFromPagedListToPagingResponse();
            CreateMapFromImageUserToImageUserDto();
            CreateMapFromPostToCreateNewPostRequest();
            CreateMapFromUserToUserDto();
            CreateMapFromCreatePostImageRequestToPostImage();
        }

        private void CreateMapFromPostToPostDto()
        {
            CreateMap<Post, PostDto>()
                .ForMember(dest => dest.Images, opts => opts.MapFrom(p => p.PostImages))
                .ForMember(dest => dest.Owner, opts => opts.MapFrom(p => p.Owner))
                .ReverseMap();
        }

        private void CreateMapFromImagePostToImagePostDto()
        {
            CreateMap<PostImage, PostImageDto>().ReverseMap();
        }

        private void CreateMapFromImageUserToImageUserDto()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }

        private void CreateMapFromPostToCreateNewPostRequest()
        {
            CreateMap<CreateNewPostRequest, Post>()
                .ForMember(des => des.PostImages, opt => opt.MapFrom(e => e.CreatePostImageRequests))
                .ForMember(des => des.OwnerId, opt => opt.MapFrom( e => Guid.Parse(e.OwnerId)));
        }

        private void CreateMapFromUserToUserDto()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
        
        private void CreateMapFromCreatePostImageRequestToPostImage()
        {
            CreateMap<CreatePostImageRequest, PostImage>().ReverseMap();
        }

        private void CreateMapFromPagedListToPagingResponse()
        {
            CreateMap<PagedList<Post>, PagingResponse<PostDto>>()
                .ForMember(des => des.CurrentPage, opt => opt.MapFrom(e => e.CurrentPage))
                .ForMember(des => des.TotalCount, opt => opt.MapFrom(e => e.TotalCount))
                .ForMember(des => des.PageSize, opt => opt.MapFrom(e => e.PageSize))
                .ForMember(des => des.TotalPages, opt => opt.MapFrom(e => e.TotalPages))
                .ForMember(des => des.HasPrevious, opt => opt.MapFrom(e => e.HasPrevious))
                .ForMember(des => des.Data, opt => opt.MapFrom(e => e.Data))
                .ReverseMap();
        }
    }
}
