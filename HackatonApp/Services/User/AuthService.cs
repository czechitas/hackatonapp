using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HackatonApp.Models;
using HackatonApp.Models.Tables;
using HackatonApp.Selectors.User;
using HackatonApp.Services.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace HackatonApp.Services.User;

public class AuthService(MyContext context, ILogger<AuthService> logger) : IAuthService
{
    public async Task<string?> AuthenticateUser(UserLoginSelector login)
    {
        // Get user from database
        var user = await context.Users.FirstOrDefaultAsync(u => u.Email == login.Email);

        // Check if user exists
        if (user == null)
            return null;
        
        // Hash password from request
        var hashedPassword = 
            System.Security.Cryptography.SHA512.HashData(Encoding.UTF8.GetBytes(login.Password));

        return hashedPassword.SequenceEqual(user.Password) ? GenerateJSONWebToken(user) : null;
    }
    
    public async Task<bool> RegisterUser(UserRegisterSelector register)
    {
        try
        {
            
            // Check if user already exists with the same email
            var existingUser = await context.Users.AnyAsync(u => u.Email == register.Email);
            if (existingUser)
                return false;
            
            var user = new Users()
            {
                Email = register.Email,
                Password = System.Security.Cryptography.SHA512.HashData(Encoding.UTF8.GetBytes(register.Password)),
                Role = UserRoles.User
            };
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            logger.LogError(e, "Failed to register user");
            return false;
        }
      
    }
    
    private string GenerateJSONWebToken(Users user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("U2VjcmV0IGlzIGEgY29tcHV0ZSBzdHJpbmc="));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var userRoleFromEnum = Enum.GetName(typeof(UserRoles), user.Role) ?? throw new Exception("Invalid user role");
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Email),
            new Claim(ClaimTypes.Role, userRoleFromEnum)
        };
        
        var token = new JwtSecurityToken("hackatonapp",
            "hackatonapp",
            claims,
            expires: DateTime.Now.AddMinutes(120),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}