using Ardalis.ApiEndpoints;
using AutoMapper;
using ES.ProductService.Api.Endpoints.Product.ViewModels;
using ES.ProductService.Application.Commands.ChangeProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ES.ProductService.Api.Endpoints.Product;

[Route(Routes.Product)]
public class Put : EndpointBaseAsync.WithRequest<ChangeProductViewModel>.WithActionResult
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public Put(
        IMapper mapper,
        IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Produces("application/json")]
    public override async Task<ActionResult> HandleAsync([FromBody] ChangeProductViewModel request,
        CancellationToken cancellationToken = new())
    {
        var changeProductCommand = _mapper.Map<ChangeProductCommand>(request);
        await _mediator.Send(changeProductCommand, cancellationToken);
        return new OkObjectResult(null);
    }
}