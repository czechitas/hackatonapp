using System.Linq.Expressions;
using HackatonApp.Models.Tables;

namespace HackatonApp.Selectors.Room;

/// <summary>
/// Room selector
/// </summary>
public class RoomSelector
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Capacity { get; set; }
    public int Price { get; set; }
    public string Image { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    /// <summary>
    /// Translate a Room table to a RoomSelector
    /// </summary>
    public static Expression<Func<Rooms, RoomSelector>> Translate = tbl =>
        new RoomSelector()
        {
            Id = tbl.Id,
            Name = tbl.Name,
            Description = tbl.Description,
            Capacity = tbl.Capacity,
            Price = tbl.Price,
            Image = tbl.Image,
            Status = tbl.Status,
            CreatedAt = tbl.CreatedAt,
            UpdatedAt = tbl.UpdatedAt
        };
}