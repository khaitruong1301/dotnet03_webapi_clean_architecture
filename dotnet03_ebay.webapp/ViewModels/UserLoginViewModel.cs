using System.ComponentModel.DataAnnotations;

public class UserLoginViewModel
{
    [Required(ErrorMessage = "Please enter your username or email.")]
    public string UsernameOrEmail { get; set; }

    [Required(ErrorMessage = "Please enter your password.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}