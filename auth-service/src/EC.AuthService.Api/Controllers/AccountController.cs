using EC.AuthService.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace EC.AuthService.Api.Controllers;

public class AccountController : Controller
{
    [HttpGet]
    [Route("signin")]
    public IActionResult SignIn()
    {
        return View();
    }

    [HttpPost]
    [Route("signin")]
    public IActionResult SignIn(SignInViewModel signInViewModel)
    {
        return View();
    }

    [HttpGet]
    [Route("signup")]
    public IActionResult SignUp(SignUpViewModel signUpViewModel)
    {
        return View();
    }

    [HttpPost]
    [Route("signup")]
    public IActionResult SignUp()
    {
        return View();
    }

    [HttpGet]
    [Route("signout")]
    public IActionResult SignOut()
    {
        return View();
    }
}