using Hotel_Reservation_System.DTO;
using Hotel_Reservation_System.Models;
using Hotel_Reservation_System.Repositaries.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Reservation_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepo _roomrepo;

        public RoomController(IRoomRepo roomrepo)
        {
            _roomrepo = roomrepo;
        }


        [HttpGet]
        [ProducesResponseType(statusCode: 204)]
        [ProducesResponseType(statusCode: 200)]
        public async Task<IActionResult> GetAllHotels()
        {
            try
            {
                var hotels = await _roomrepo.GetAllRoomAsync();
                return Ok(hotels);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpGet("{id}")]
        [ProducesResponseType(statusCode: 204)]
        [ProducesResponseType(statusCode: 200)]
        public async Task<IActionResult> GetRoomById(int id)
        {
            try
            {
                var hotel = await _roomrepo.GetRoomByIdAsync(id);
                if (hotel == null)
                {
                    return NotFound();
                }
                return Ok(hotel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]


        [ProducesResponseType(statusCode: 201)]
        [ProducesResponseType(statusCode: 409)]
        public async Task<IActionResult> PostHotels([FromBody] CreateRoomDto room)
        {
            try
            {
                if (room == null)
                {
                    return BadRequest();
                }
                var addedHotel = await _roomrepo.PostRoomAsync(room);
                return CreatedAtAction(nameof(GetRoomById), new { id = addedHotel.Room_Id }, addedHotel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, [FromBody] Room room
            )
        {
            try
            {
                if (room == null || room.Room_Id != id)
                {
                    return BadRequest();
                }
                var updatedHotel = await _roomrepo.PutRoomAsync(id, room);
                if (updatedHotel == null)
                {
                    return NotFound();
                }
                return Ok(updatedHotel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DelHotels(int id)
        {
            try
            {
                var room = await _roomrepo.DelRoomAsync(id);
                if (room == null)
                {
                    return NotFound();
                }
                return Ok(room);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("capacity")]
        public async Task<IActionResult> GetCapacity(string type, int capacity)
        {
            try
            {
                var room = await _roomrepo.GetRoomsByTypeAndCapacityAsync(type, capacity);
                if (room == null)
                {
                    return NotFound();
                }
                return Ok(room);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
