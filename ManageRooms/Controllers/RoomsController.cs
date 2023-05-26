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
        public RoomsController(IRepo<int, Rooms> repo)
        {
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
            var updateHotel = _repo.Update(rooms);
            if (updateHotel == null)
            {
                return BadRequest("Unable to update");
            }
            return Ok(updateHotel);
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
            var getOneHotel = _repo.Get(key);
            if (getOneHotel == null)
            {
                return BadRequest("Unable to fetch");
            }
            return Ok(getOneHotel);
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
            var getAllHotel = _repo.GetAll();
            if (getAllHotel == null)
            {
                return BadRequest("Unable to fetch");
            }
            return Ok(getAllHotel);
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
            var getAllHotel = _repo.Delete(key);
            if (getAllHotel == null)
            {
                return BadRequest("Unable to delete");
            }
            return Ok(getAllHotel);
        }
    }
}
