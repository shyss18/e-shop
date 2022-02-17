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
            .ForPath(dest => dest.AgentId, opt => opt.MapFrom(src => src.Agent.Id))
            .ReverseMap();

        CreateMap<Agent, AgentModel>()
            .ForPath(dest => dest.CompanyId, opt => opt.MapFrom(src => src.Company.Id))
            .ReverseMap();

        CreateMap<Company, CompanyModel>()
            .ReverseMap();

        CreateMap<Expression<Func<Product, bool>>, Expression<Func<ProductModel, bool>>>();
    }
}