using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HackatonApp.Models.Tables
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(30)]
        public required string Email { get; set; }
        
        public required byte[] Password { get; set; }
        
        public required UserRoles Role { get; set; } = UserRoles.User;
        
        public string? FirstName { get; set; }
        
        public string? LastName { get; set; }
        
        public string? PhoneNumber { get; set; }
        
        public string? Address { get; set; }
        
        public string? City { get; set; }
        
        public string? Country { get; set; }
        
        public string? PostalCode { get; set; }
        
        public string? ProfilePicture { get; set; }
    }
}
