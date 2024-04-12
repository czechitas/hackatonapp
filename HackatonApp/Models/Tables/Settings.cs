using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HackatonApp.Models.Tables
{
    public class Settings
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(30)]
        public required string Name { get; set; }

        [MaxLength(512)]
        public required string Value { get; set; }
    }
}
