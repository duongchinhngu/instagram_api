using AutoMapper;
using Instagram.Helpers;
using Instagram.HttpMessages.Dtos;
using Instagram.HttpMessages.Responses;
using Instagram.Models;
using System.Collections.Generic;

namespace Instagram.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMapFromImagePostToImagePostDto();
            CreateMapFromPostToPostDto();
            CreateMapFromPagedListToPagingResponse();
        }

        private void CreateMapFromPostToPostDto()
        {
            CreateMap<Post, PostDto>()
                .ForMember(dest => dest.Images, opts => opts.MapFrom(p => p.PostImages))
                .ReverseMap();
        }

        private void CreateMapFromImagePostToImagePostDto()
        {
            CreateMap<PostImage, PostImageDto>().ReverseMap();
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
