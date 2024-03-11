using System.ComponentModel.DataAnnotations;

namespace HackatonApp.Models.Tables
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        public required string Email { get; set; }
    }
}
