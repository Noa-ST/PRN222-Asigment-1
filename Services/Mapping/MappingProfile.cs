using AutoMapper;
using BusinessObjects.DTOs;
using BusinessObjects.Entities;

namespace Services.Mapping
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, GetCategoryDto>().ReverseMap();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();

            CreateMap<NewsArticle, GetNewsArticleDto>().ReverseMap();
            CreateMap<CreateNewsArticleDto, NewsArticle>();
            CreateMap<UpdateNewsArticleDto, NewsArticle>();

            CreateMap<SystemAccount, GetSystemAccountDto>().ReverseMap();
            CreateMap<CreateSystemAccountDto, SystemAccount>();
            CreateMap<UpdateSystemAccountDto, SystemAccount>();

            CreateMap<Taq, GetTaqDto>().ReverseMap();
            CreateMap<CreateTaqDto, Taq>();
            CreateMap<UpdateTaqDto, Taq>();
        }
    }

}
