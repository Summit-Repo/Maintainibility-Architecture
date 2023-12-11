using AutoMapper;
using CleanArchitectureService.DTO;
using Domain.Entities;
//using Domain.Entities;

namespace CleanArchitectureService
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Users, UserDto>().ReverseMap();
            CreateMap<Product,ProductDto >().ReverseMap();
        }
    }
}
