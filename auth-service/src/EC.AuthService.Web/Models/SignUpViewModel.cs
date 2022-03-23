using System.ComponentModel.DataAnnotations;

namespace EC.AuthService.Web.Models;

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
}