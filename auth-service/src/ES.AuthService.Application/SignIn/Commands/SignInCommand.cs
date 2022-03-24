using MediatR;

namespace ES.AuthService.Application.SignIn.Commands;

public class SignInCommand : IRequest
{
    public string Email { get; set; }

    public string Password { get; set; }
}