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
    }
}
