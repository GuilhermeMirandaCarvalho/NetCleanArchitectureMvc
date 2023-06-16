using AutoMapper;
using NetCleanArchitectureMvc.Application.DTOs;
using NetCleanArchitectureMvc.Domain.Entities;

namespace NetCleanArchitectureMvc.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
