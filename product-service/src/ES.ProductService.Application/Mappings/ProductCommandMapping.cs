using AutoMapper;
using ES.ProductService.Application.Commands.ChangeProduct;
using ES.ProductService.Application.Commands.CreateProduct;
using ES.ProductService.Domain.Entities;

namespace ES.ProductService.Application.Mappings;

public class ProductCommandMapping : Profile
{
    public ProductCommandMapping()
    {
        CreateMap<CreateProductCommand, Product>()
            .ForMember(dest => dest.Agent.Id, opt => opt.MapFrom(src => src.AgentId));

        CreateMap<ChangeProductCommand, Product>();
    }
}