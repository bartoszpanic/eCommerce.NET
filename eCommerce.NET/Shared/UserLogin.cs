using System.ComponentModel.DataAnnotations;

namespace eCommerce.NET.Shared;

public class UserLogin
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
}