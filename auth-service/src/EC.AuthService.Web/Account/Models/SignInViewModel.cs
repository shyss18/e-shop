using System.ComponentModel.DataAnnotations;

namespace EC.AuthService.Web.Account.Models;

public class SignInViewModel
{
    [Required] [EmailAddress] public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    public string RedirectUrl { get; set; }
}