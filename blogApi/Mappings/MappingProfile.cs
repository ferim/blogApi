using AutoMapper;
using blogApi.Extensions;
using Entities.Models;
using Shared.DataTransferObjects;

namespace blogApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Article, ArticleDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<CreateArticleDto, Article>()
                .ForMember(dest => dest.SeoUrl, opt => opt.MapFrom(src => src.Title.SeoFriendlyUrl())).IgnoreUnmapped("Categories");
            CreateMap<UpdateArticleDto, Article>()
                .ForMember(dest => dest.SeoUrl, opt => opt.MapFrom(src => src.Title.SeoFriendlyUrl()))
                .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.Now))
                .IgnoreUnmapped("Categories").ReverseMap();
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();
            CreateMap<UserForRegistrationDto, User>();
        }
    }
}
