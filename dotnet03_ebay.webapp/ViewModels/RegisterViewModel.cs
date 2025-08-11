using System.ComponentModel.DataAnnotations;

namespace  dotnet03_ebay.webapp.ViewModels;

public class RegisterViewModel
{
    [Required]
    public string UserName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(6)]
    public string Password { get; set; }

    [Required]
    public string FullName { get; set; }
}
