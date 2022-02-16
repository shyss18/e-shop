using Ardalis.ApiEndpoints;
using AutoMapper;
using ES.ProductService.Api.Endpoints.Product.ViewModels;
using ES.ProductService.Application.Queries.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ES.ProductService.Api.Endpoints.Product;

[Route(Routes.Product)]
public class Get : EndpointBaseAsync.WithoutRequest.WithActionResult<ProductViewModel[]>
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public Get(
        IMapper mapper,
        IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductViewModel[]))]
    [Produces("application/json")]
    public override async Task<ActionResult<ProductViewModel[]>> HandleAsync(
        CancellationToken cancellationToken = new())
    {
        var products = await _mediator.Send(new ProductsQuery(), cancellationToken);
        var productViewModels = _mapper.Map<ProductViewModel[]>(products);
        return new OkObjectResult(productViewModels);
    }
}