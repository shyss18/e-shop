using AutoMapper;
using ES.AuthService.Application.SignIn.Commands;
using ES.AuthService.Application.SignUp;
using ES.AuthService.Application.SignUp.Commands;
using ES.AuthService.Web.Account.Models;

namespace ES.AuthService.Web.Account.Mappings;

public class Mappings : Profile
{
    public Mappings()
    {
        CreateMap<SignInViewModel, SignInCommand>();
        CreateMap<SignUpViewModel, SignUpCommand>();
    }
}