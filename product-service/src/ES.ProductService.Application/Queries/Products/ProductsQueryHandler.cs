using ES.ProductService.Domain.Entities;
using MediatR;

namespace ES.ProductService.Application.Queries.Products;

public class ProductsQueryHandler : IRequestHandler<ProductsQuery, Product[]>
{
    public Task<Product[]> Handle(ProductsQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Array.Empty<Product>());
    }
}