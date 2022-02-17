using AutoMapper;
using ES.ProductService.Application.Contracts.Repositories;
using ES.ProductService.Domain.Entities;
using MediatR;

namespace ES.ProductService.Application.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Product> _repository;

    public CreateProductCommandHandler(
        IMapper mapper,
        IGenericRepository<Product> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(request);
        await _repository.CreateAsync(product, cancellationToken);
        return Unit.Value;
    }
}