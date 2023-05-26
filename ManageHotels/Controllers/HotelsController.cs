using HotelAPI.Services;
using ManageHotels.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistrationAndLogin.Model;

namespace ManageHotels.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly HotelRepo _repo;

        public HotelsController(HotelRepo repo)
        {
                 _repo = repo;  
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ICollection<Hotels>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Hotels> Add([FromBody] Hotels hotel)
        {
            var addHotel = _repo.Add(hotel);
            if (addHotel == null)
            {
                return BadRequest("Unable to register");
            }
            return Created("Welcome", addHotel);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ICollection<HotelDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<HotelDTO> Update([FromBody] Hotels hotel)
        {
            var updateHotel = _repo.Update(hotel);
            if (updateHotel == null)
            {
                return BadRequest("Unable to register");
            }
            return Ok(updateHotel);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ICollection<HotelDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<HotelDTO> Get([FromBody] int key)
        {
            var getOneHotel = _repo.Get(key);
            if (getOneHotel == null)
            {
                return BadRequest("Unable to register");
            }
            return Ok(getOneHotel);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ICollection<HotelDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<HotelDTO> GetAll()
        {
            var getAllHotel = _repo.GetAll();
            if (getAllHotel == null)
            {
                return BadRequest("Unable to register");
            }
            return Ok(getAllHotel);
        }
    }
}
