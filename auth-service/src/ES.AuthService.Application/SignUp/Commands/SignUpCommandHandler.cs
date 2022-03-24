using EC.AuthService.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace ES.AuthService.Application.SignUp.Commands;

public class SignUpCommandHandler : IRequestHandler<SignUpCommand>
{
    private readonly UserManager<EsIdentityUser> _userManager;
    private readonly ILogger<SignUpCommandHandler> _logger;

    public SignUpCommandHandler(
        UserManager<EsIdentityUser> userManager,
        ILogger<SignUpCommandHandler> logger)
    {
        _userManager = userManager;
        _logger = logger;
    }

    public async Task<Unit> Handle(SignUpCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user is not null) throw new Exception();

        var newUser = new EsIdentityUser
        {
            Email = request.Email,
            UserName = request.Name + " " + request.Surname
        };

        await _userManager.CreateAsync(newUser, request.Password);

        _logger.LogInformation("User with email := {Email} has created", request.Email);

        return Unit.Value;
    }
}