namespace HackatonApp.Selectors.User;

/// <summary>
/// User register selector
/// </summary>
public class UserRegisterSelector
{
    /// <summary>
    /// User email
    /// </summary>
    public string Email { get; set; }
    /// <summary>
    /// User password - to be hashed
    /// </summary>
    public string Password { get; set; }
}