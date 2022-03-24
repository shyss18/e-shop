using MediatR;

namespace ES.AuthService.Application.SignUp.Commands;

public class SignUpCommand : IRequest
{
    public string Email { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }

    public string Password { get; set; }
}