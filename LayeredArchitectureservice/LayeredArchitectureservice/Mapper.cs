using AutoMapper;
using DataAccess.Domain;
using LayeredArchitectureservice.Dto;

namespace LayeredArchitectureservice
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<Users, UserDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
