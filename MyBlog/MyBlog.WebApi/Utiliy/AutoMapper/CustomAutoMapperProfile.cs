using AutoMapper;
using MyBlog.Model;
using MyBlog.Model.DTO;

namespace MyBlog.WebApi.Utiliy.AutoMapper
{
    public class CustomAutoMapperProfile:Profile
    {
        public CustomAutoMapperProfile() {
            base.CreateMap<WriterInfo,WriterInfoDTO>();
            base.CreateMap<BlogNews, BlogNewsDTO>().
                ForMember(dest=>dest.TypeName,source=>source.MapFrom(src=>src.TypeInfo.Name))
                .ForMember(dest => dest.WriterName, source => source.MapFrom(src => src.WriterInfo.Name));
        }    
    }
}
