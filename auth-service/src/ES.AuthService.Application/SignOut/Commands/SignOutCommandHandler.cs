using EC.AuthService.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace ES.AuthService.Application.SignOut.Commands;

public class SignOutCommandHandler : IRequestHandler<SignOutCommand>
{
    private readonly SignInManager<EsIdentityUser> _signInManager;
    private readonly ILogger<SignOutCommandHandler> _logger;

    public SignOutCommandHandler(
        SignInManager<EsIdentityUser> signInManager,
        ILogger<SignOutCommandHandler> logger)
    {
        _signInManager = signInManager;
        _logger = logger;
    }

    public async Task<Unit> Handle(SignOutCommand request, CancellationToken cancellationToken)
    {
        await _signInManager.SignOutAsync();
        _logger.LogInformation("User with email := {Email} has signed out", request.Email);
        return Unit.Value;
    }
}