using System.Linq.Expressions;
using AutoMapper;
using ES.ProductService.Domain.Entities;
using ES.ProductService.Infrastructure.Models;

namespace ES.ProductService.Infrastructure.Mappings;

public class ProductModelMapping : Profile
{
    public ProductModelMapping()
    {
        CreateMap<Product, ProductModel>()
            .ForMember(dest => dest.AgentId, opt => opt.MapFrom(src => src.Agent.Id))
            .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images))
            .ReverseMap();

        CreateMap<Expression<Func<Product, bool>>, Expression<Func<ProductModel, bool>>>();
    }
}