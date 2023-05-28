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
        private readonly IRepo<int, Rooms> _repo;
        private readonly RoomsService _service;
        public RoomsController(IRepo<int, Rooms> repo, RoomsService service)
        {
            _service = service; 
            _repo = repo;
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
            var addRooms = _repo.Add(rooms);
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

        public ActionResult<Rooms> Update([FromBody] Rooms rooms)
        {
            var updateRoom = _repo.Update(rooms);
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

        public ActionResult<Rooms> Get([FromBody] int key)
        {
            var getOneRoom = _repo.Get(key);
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

        public ActionResult<Rooms> GetAll()
        {
            var getAllRoom = _repo.GetAll();
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

        public ActionResult<Rooms> Delete(int key)
        {
            var deleteRoom = _repo.Delete(key);
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
            return Ok(hotelRooms);
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

        public ActionResult<Rooms> PriceRange(int minimumPrice, int maximumPrice)
        {
            var hotelRooms = _service.PriceRange(minimumPrice, maximumPrice);
            if (hotelRooms.Count == 0)
            {
                return NotFound("No Rooms is available right now");
            }
            return Ok(hotelRooms);
        }
    }
}
