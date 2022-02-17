using AutoMapper;
using ES.ProductService.Api.Endpoints.Product.ViewModels;
using ES.ProductService.Application.Commands.ChangeProduct;
using ES.ProductService.Application.Commands.CreateProduct;

namespace ES.ProductService.Api.Endpoints.Product.Mappings;

public class ProductViewModelMapping : Profile
{
    public ProductViewModelMapping()
    {
        CreateMap<ProductViewModel, Domain.Entities.Product>()
            .ReverseMap();

        CreateMap<ChangeProductViewModel, ChangeProductCommand>();
        CreateMap<CreateProductViewModel, CreateProductCommand>();
    }
}