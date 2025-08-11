using System.ComponentModel.DataAnnotations;

public class UserLoginDTO
{

    [Required(ErrorMessage = "Please enter your username or email.")]
    public string? UsernameOrEmail { get; set; }
     [Required(ErrorMessage = "Please enter your password.")]
    public string? Password { get; set; }
    
}