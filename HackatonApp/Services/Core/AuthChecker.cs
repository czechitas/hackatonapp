using Blazored.LocalStorage;

namespace HackatonApp.Services.Core;


public class AuthChecker(ILocalStorageService localStorage, ILogger<AuthChecker> logger)
{

    private ILocalStorageService _localStorage = localStorage;

    // Check if the user is authenticated by token from localstorage
    public async Task<bool> IsAuthenticatedAsync()
    {
        logger.LogInformation("Checking if user is authenticated");
        var token = await _localStorage.GetItemAsStringAsync("token");
        return token != null;
    }
    
    public async Task<string> GetTokenAsync()
    {
        return await _localStorage.GetItemAsStringAsync("token") ?? throw new Exception("Token not found");
    }
}