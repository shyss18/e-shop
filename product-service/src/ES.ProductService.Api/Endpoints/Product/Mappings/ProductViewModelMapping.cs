using AutoMapper;
using ES.ProductService.Api.Endpoints.Product.ViewModels;

namespace ES.ProductService.Api.Endpoints.Product.Mappings;

public class ProductViewModelMapping : Profile
{
    public ProductViewModelMapping()
    {
        CreateMap<ProductViewModel, Domain.Entities.Product>()
            .ReverseMap();
    }
}