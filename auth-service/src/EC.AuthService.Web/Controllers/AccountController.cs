using EC.AuthService.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EC.AuthService.Web.Controllers;

[AllowAnonymous]
public class AccountController : Controller
{
    [HttpGet("signin")]
    public IActionResult SignIn()
    {
        return View("SignIn");
    }

    [HttpPost("signin")]
    public IActionResult SignIn(SignInViewModel signInViewModel)
    {
        return View(signInViewModel);
    }

    [HttpGet("signup")]
    public IActionResult SignUp()
    {
        return View("SignUp");
    }

    [HttpPost("signup")]
    public IActionResult SignUp(SignUpViewModel signUpViewModel)
    {
        return View(signUpViewModel);
    }

    [HttpPost("signout")]
    public IActionResult SignOut()
    {
        return Ok();
    }
}