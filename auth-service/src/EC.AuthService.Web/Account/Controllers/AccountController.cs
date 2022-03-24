using AutoMapper;
using EC.AuthService.Web.Account.Models;
using ES.AuthService.Application.SignIn.Commands;
using ES.AuthService.Application.SignOut.Commands;
using ES.AuthService.Application.SignUp.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EC.AuthService.Web.Account.Controllers;

[AllowAnonymous]
public class AccountController : Controller
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public AccountController(
        IMapper mapper,
        IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet("signin")]
    public IActionResult SignIn()
    {
        return View();
    }

    [HttpPost("signin")]
    public async Task<IActionResult> SignIn(SignInViewModel signInViewModel, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
            return View(signInViewModel);

        var command = _mapper.Map<SignInCommand>(signInViewModel);
        await _mediator.Send(command, cancellationToken);

        return Redirect(signInViewModel.RedirectUrl);
    }

    [HttpGet("signup")]
    public IActionResult SignUp()
    {
        return View();
    }

    [HttpPost("signup")]
    public async Task<IActionResult> SignUp(SignUpViewModel signUpViewModel, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
            return View(signUpViewModel);

        var command = _mapper.Map<SignUpCommand>(signUpViewModel);
        await _mediator.Send(command, cancellationToken);

        return Redirect(signUpViewModel.RedirectUrl);
    }

    [HttpPost("signout")]
    public async Task<IActionResult> SignOut(string email, CancellationToken cancellationToken)
    {
        await _mediator.Send(new SignOutCommand
        {
            Email = email
        }, cancellationToken);
        return Ok();
    }
}