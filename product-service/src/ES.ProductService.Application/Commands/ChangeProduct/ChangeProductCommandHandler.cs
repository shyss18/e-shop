using MediatR;

namespace ES.ProductService.Application.Commands.ChangeProduct;

public class ChangeProductCommandHandler : IRequestHandler<ChangeProductCommand>
{
    public Task<Unit> Handle(ChangeProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}