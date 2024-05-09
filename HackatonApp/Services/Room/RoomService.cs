using HackatonApp.Models.Tables;
using HackatonApp.Selectors.Room;
using HackatonApp.Services.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HackatonApp.Services.Room
{
    /// <summary>
    /// Room service
    /// </summary>
    /// <param name="context"></param>
    /// <param name="logger"></param>
    public class RoomService(MyContext context, ILogger<RoomService> logger) : IRoomService
    {
        public void CreateTestRoom()
        {
            var room = new Rooms()
            {
                Name = "Test Room",
                Description = "This is a test room",
                Capacity = 10,
                Price = 100,
                Image = "https://example.com/image.jpg",
                Status = "available",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            logger.LogDebug("Creating room");
            context.Rooms.Add(room);
            context.SaveChanges();
            logger.LogDebug($"Room created {room.Id}");
        }
        
        /// <summary>
        /// Get a list of rooms
        /// </summary>
        /// <returns></returns>
        public async Task<List<RoomSelector>> GetRooms()
        {
            logger.LogDebug("Getting rooms");
            return await context.Rooms.Select(RoomSelector.Translate).ToListAsync();
        }
        
        public async Task<RoomSelector?> GetRoom(int id)
        {
            logger.LogDebug($"Getting room {id}");
            return await context.Rooms.Select(RoomSelector.Translate).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> RemoveRoom(int id)
        {
            logger.LogDebug($"Removing room {id}");
            
            var room = await context.Rooms.FirstOrDefaultAsync(x => x.Id == id);
            if (room == null)
            {
                logger.LogWarning($"Room {id} not found");
                return false;
            }
            
            context.Rooms.Remove(room);
            await context.SaveChangesAsync();
            logger.LogDebug($"Room {id} removed");
            return true;
        }
    }
}
