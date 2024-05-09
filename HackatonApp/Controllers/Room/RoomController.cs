using HackatonApp.Services.Room;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HackatonApp.Controllers.Room
{
    /// <summary>
    /// Room controller
    /// </summary>
    /// <param name="roomService"></param>
    [ApiController]
    [Route("api/room")]
    public class RoomController(IRoomService roomService) : ControllerBase
    {
        /// <summary>
        /// Create a room for testing
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public Task<IActionResult> CreateRoom()
        {
            roomService.CreateTestRoom();
            return Task.FromResult<IActionResult>(Ok());
        }
        
        /// <summary>
        /// Return a list of rooms by parameters
        /// </summary> 
        /// <returns></returns>
        [HttpGet("rooms")]
        [AllowAnonymous]
        //[Authorize(Roles = nameof(UserRoles.Admin))]
        public async Task<IActionResult> ListRooms()
        {
            var rooms = await roomService.GetRooms();
            return Ok(rooms);
        }
        
        /// <summary>
        /// Return a room by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetRoom(int id)
        {
            var room = await roomService.GetRoom(id);
            if (room == null)
                return NotFound();
            return Ok(room);
        }
        
        /// <summary>
        /// Remove a room by id
        /// </summary>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> RemoveRoom(int id)
        {
            var result = await roomService.RemoveRoom(id);
            if (!result)
                return NotFound();
            return Ok();
        }
    }
}
