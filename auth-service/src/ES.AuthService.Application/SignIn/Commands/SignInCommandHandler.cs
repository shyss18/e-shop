using EC.AuthService.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace ES.AuthService.Application.SignIn.Commands;

public class SignInCommandHandler : IRequestHandler<SignInCommand>
{
    private readonly SignInManager<EsIdentityUser> _signInManager;
    private readonly UserManager<EsIdentityUser> _userManager;
    private readonly ILogger<SignInCommandHandler> _logger;

    public SignInCommandHandler(
        SignInManager<EsIdentityUser> signInManager,
        UserManager<EsIdentityUser> userManager,
        ILogger<SignInCommandHandler> logger)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _logger = logger;
    }

    public async Task<Unit> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user is null) throw new ArgumentException();

        var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);
        if (!isPasswordValid) throw new Exception();

        await _signInManager.SignInAsync(user, true);

        _logger.LogInformation("User with email := {Email} has signed in", request.Email);

        return Unit.Value;
    }
}