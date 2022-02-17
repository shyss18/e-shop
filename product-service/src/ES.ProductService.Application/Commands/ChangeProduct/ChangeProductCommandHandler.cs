using AutoMapper;
using ES.ProductService.Application.Contracts.Repositories;
using ES.ProductService.Domain.Entities;
using MediatR;

namespace ES.ProductService.Application.Commands.ChangeProduct;

public class ChangeProductCommandHandler : IRequestHandler<ChangeProductCommand>
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Product> _repository;

    public ChangeProductCommandHandler(
        IMapper mapper,
        IGenericRepository<Product> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Unit> Handle(ChangeProductCommand request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(request);
        await _repository.ChangeAsync(product, cancellationToken);
        return Unit.Value;
    }
}