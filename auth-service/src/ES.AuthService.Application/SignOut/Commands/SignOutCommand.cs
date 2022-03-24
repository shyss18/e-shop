using MediatR;

namespace ES.AuthService.Application.SignOut.Commands;

public class SignOutCommand : IRequest
{
    public string Email { get; set; }
}