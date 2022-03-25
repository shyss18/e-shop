using System.ComponentModel.DataAnnotations;

namespace ES.AuthService.Web.Account.Models;

public class SignUpViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    public string Name { get; set; }

    public string Surname { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    public string RedirectUrl { get; set; }
}