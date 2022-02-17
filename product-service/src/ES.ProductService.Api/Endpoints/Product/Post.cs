using Ardalis.ApiEndpoints;
using AutoMapper;
using ES.ProductService.Api.Endpoints.Product.ViewModels;
using ES.ProductService.Application.Commands.CreateProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ES.ProductService.Api.Endpoints.Product;

[Route(Routes.Product)]
public class Post : EndpointBaseAsync.WithRequest<CreateProductViewModel>.WithActionResult
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public Post(
        IMapper mapper,
        IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Produces("application/json")]
    public override async Task<ActionResult> HandleAsync([FromBody] CreateProductViewModel request,
        CancellationToken cancellationToken = new())
    {
        var createProductCommand = _mapper.Map<CreateProductCommand>(request);
        await _mediator.Send(createProductCommand, cancellationToken);
        return new OkObjectResult(null);
    }
}