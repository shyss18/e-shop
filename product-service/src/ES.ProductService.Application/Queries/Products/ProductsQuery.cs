using ES.ProductService.Domain.Entities;
using MediatR;

namespace ES.ProductService.Application.Queries.Products;

public class ProductsQuery : IRequest<Product[]>
{
    
}