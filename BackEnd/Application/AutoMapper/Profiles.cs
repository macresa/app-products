using Application.DTO;
using AutoMapper;
using Domain.Entities;

namespace Application.AutoMapper
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Product, PostProductDTO>().ReverseMap();
            CreateMap<Product, PutProductDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<PostProductDTO, PutProductDTO>();
        }
    }
}
