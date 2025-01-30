using AutoMapper;
using ProductManagementSystem.Entities;

namespace ProductManagementSystem.APIService.Mapping
{
    public class AutoMapperPofile : Profile
    {
        public AutoMapperPofile()
        {

            //CreateMap<Product, ProductReadDto>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            //    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            //    .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));

            //CreateMap<ProductWriteDto, Product>()
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            //     .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            //    .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));

            CreateMap<Product, ProductReadDto>();
            CreateMap<ProductWriteDto, Product>();
        }
    }
}
