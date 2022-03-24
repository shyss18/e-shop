using AutoMapper;
using EC.AuthService.Web.Account.Models;
using ES.AuthService.Application.SignIn.Commands;
using ES.AuthService.Application.SignUp;
using ES.AuthService.Application.SignUp.Commands;

namespace EC.AuthService.Web.Account.Mappings;

public class Mappings : Profile
{
    public Mappings()
    {
        CreateMap<SignInViewModel, SignInCommand>();
        CreateMap<SignUpViewModel, SignUpCommand>();
    }
}