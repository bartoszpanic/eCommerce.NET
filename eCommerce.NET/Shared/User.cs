namespace eCommerce.NET.Shared;

public class User
{
    public virtual int Id  { get; set; }
    public virtual string Email { get; set; } = string.Empty;
    public virtual byte[] PasswordHash { get; set; }
    public virtual byte[] PasswordSalt { get; set; }
    public virtual DateTime DateCreated { get; set; } = DateTime.Now;
}