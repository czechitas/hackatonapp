using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HackatonApp.Models.Tables
{
    public class Rooms
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(30)]
        public required string Name { get; set; }

        public required string Description { get; set; }

        public required int Capacity { get; set; }

        public required int Price { get; set; }

        public required string Image { get; set; }

        public required string Status { get; set; }

        public required DateTime CreatedAt { get; set; }

        public required DateTime UpdatedAt { get; set; }
    }
}
