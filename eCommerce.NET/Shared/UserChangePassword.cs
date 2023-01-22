using System.ComponentModel.DataAnnotations;

namespace eCommerce.NET.Shared;

public class UserChangePassword
{
    [Required, StringLength(10, MinimumLength = 6)]
    public string Password { get; set; } = string.Empty;
    [Compare("Password", ErrorMessage = "The password not match.")]
    public string ConfirmPassword { get; set; } = string.Empty;
}