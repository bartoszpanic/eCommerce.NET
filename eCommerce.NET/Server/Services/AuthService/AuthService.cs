using System.Security.Cryptography;
using eCommerce.NET.Shared;

namespace eCommerce.NET.Server.Services.AuthService;

public class AuthService : IAuthService
{
    private readonly DataContext _context;

    public AuthService(DataContext context)
    {
        _context = context;
    }
    public async Task<ServiceResponse<int>> Register(User user, string password)
    {
        if (await UserExist(user.Email))
        {
            return new ServiceResponse<int>() { Success = false, Message = "User exist"};
        }

        CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return new ServiceResponse<int>() {Success = true, Message = "User register successful", Data = user.Id};
    }

    private async Task<bool> UserExist(string email)
    {
        return await _context.Users.AnyAsync(user => user.Email.ToLower().Equals(email.ToLower()));
    }

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
}