using HackatonApp.Selectors.User;

namespace HackatonApp.Services.User;

public interface IAuthService
{
    public Task<string?> AuthenticateUser(UserLoginSelector login);
    public Task<bool> RegisterUser(UserRegisterSelector register);
}