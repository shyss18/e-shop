using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EC.AuthService.Web.Models;

public class SignInViewModel
{
    [Required]
    [EmailAddress]
    [DisplayName("Some email")]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}