using System.ComponentModel.DataAnnotations;

namespace ES.AuthService.Web.Account.Models;

public class SignInViewModel
{
    [Required] [EmailAddress] public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    public string RedirectUrl { get; set; }
}