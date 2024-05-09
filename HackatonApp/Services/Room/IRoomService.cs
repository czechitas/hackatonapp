using HackatonApp.Models.Tables;
using HackatonApp.Selectors.Room;
using Microsoft.AspNetCore.Mvc;

namespace HackatonApp.Services.Room
{
    public interface IRoomService
    {
        public void CreateTestRoom();
        /// <summary>
        /// Get a list of rooms
        /// </summary>
        /// <returns></returns>
        public Task<List<RoomSelector>> GetRooms();
        public Task<RoomSelector?> GetRoom(int id);
        public Task<bool> RemoveRoom(int id);
    }
}
