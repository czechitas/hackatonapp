namespace HackatonApp.Models;

/// <summary>
/// A static class that defines the available user roles in the application.
/// </summary>
public enum UserRoles
{
    /// <summary>
    /// A user that can only view the application.
    /// </summary>
    User = 0,
    /// <summary>
    /// A user that can view and edit the application.
    /// </summary>
    Admin = 1
}
