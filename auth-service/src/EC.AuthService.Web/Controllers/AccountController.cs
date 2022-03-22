using EC.AuthService.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EC.AuthService.Web.Controllers;

[AllowAnonymous]
public class AccountController : Controller
{
    [HttpGet]
    [Route("signin")]
    public IActionResult SignIn()
    {
        return View("SignIn");
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
        return View("SignUp");
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
        return View("SignOut");
    }
}