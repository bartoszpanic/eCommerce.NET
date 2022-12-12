namespace eCommerce.NET.Shared;

public class UserRegister
{
    public virtual string Email { get; set; } = string.Empty;
    public virtual string Password { get; set; } = string.Empty;
    public virtual string ConfirmPassword { get; set; } = string.Empty;
}