using ManageRooms.Interfaces;
using ManageRooms.Models;
using ManageRooms.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManageRooms.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        //private readonly IRepo<int, Rooms> _service;
        private readonly RoomsService _service;
        public RoomsController(IRepo<int, Rooms> repo, RoomsService service)
        {
            _service = service; 
            //_service = repo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rooms"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ICollection<Rooms>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Rooms> AddRooms([FromBody] Rooms rooms)
        {
            var addRooms = _service.AddRooms(rooms);
            if (addRooms == null)
            {
                return BadRequest("Unable to add");
            }
            return Created("Welcome", addRooms);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rooms"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ICollection<Rooms>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<Rooms> UpdateRooms([FromBody] Rooms rooms)
        {
            var updateRoom = _service.UpdateRooms(rooms);
            if (updateRoom == null)
            {
                return BadRequest("Unable to update");
            }
            return Ok(updateRoom);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Rooms>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<Rooms> GetOneRoom(int key)
        {
            var getOneRoom = _service.GetOneRoom(key);
            if (getOneRoom == null)
            {
                return BadRequest("Unable to fetch");
            }
            return Ok(getOneRoom);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Rooms>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<Rooms> GetAllRooms()
        {
            var getAllRoom = _service.GetAllRooms();
            if (getAllRoom == null)
            {
                return BadRequest("Unable to fetch");
            }
            return Ok(getAllRoom);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Rooms>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<Rooms> DeleteRooms(int key)
        {
            var deleteRoom = _service.DeleteRooms(key);
            if (deleteRoom == null)
            {
                return BadRequest("Unable to delete");
            }
            return Ok(deleteRoom);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Rooms>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<Rooms> HotelRoom(int hotelId)
        {
            var hotelRooms = _service.RoomsofHotels(hotelId);
            if (hotelRooms.Count == 0)
            {
                return NotFound("No Rooms under this hotel");
            }
            return Ok(hotelRooms);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        ///

        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Rooms>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<Rooms> AvailableRooms(int hotelId)
        {
            var hotelRooms = _service.CountAvailableRooms(hotelId);
            if (hotelRooms.Count == 0)
            {
                return NotFound("No Rooms is available right now");
            }
            return Ok(hotelRooms.Count);
        }
        
         /// <summary>
         /// 
         /// </summary>
         /// <param name="amenties"></param>
         /// <returns></returns>

        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Rooms>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<Rooms> Amenties(string amenties)
        {
            var hotelRooms = _service.AvailableAmenties(amenties);
            if (hotelRooms.Count == 0)
            {
                return NotFound("No Rooms is available right now");
            }
            return Ok(hotelRooms);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="minimumPrice"></param>
        /// <param name="maximumPrice"></param>
        /// <returns></returns>

        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Rooms>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<Rooms> PriceRange(double minimumPrice, double maximumPrice)
        {
            var hotelRooms = _service.PriceRange(minimumPrice, maximumPrice);
            if (hotelRooms == null)
            {
                return NotFound("No room is available right now");
            }
            return Ok(hotelRooms);
        }
    }
}
