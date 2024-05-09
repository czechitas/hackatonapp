namespace HackatonApp.Selectors.User;

/// <summary>
/// User login selector for login request
/// </summary>
public class UserLoginSelector
{
    /// <summary>
    /// Email of the user
    /// </summary>
    public required string Email { get; set; }
    /// <summary>
    /// Password of the user
    /// </summary>
    public required string Password { get; set; }
}