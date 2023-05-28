using HotelAPI.Services;
using ManageHotels.Interfaces;
using ManageHotels.Model.DTO;
using ManageHotels.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistrationAndLogin.Model;

namespace ManageHotels.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly HotelService _service;

        public HotelsController(IRepo<int, Hotels> repo, HotelService service)
        {
            _service = service;
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
            var addHotel = _service.AddHotel(hotel);
            if (addHotel == null)
            {
                return BadRequest("Unable to add");
            }
            return Ok(addHotel);
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

        public ActionResult<Hotels> Update([FromBody] Hotels hotel)
        {
            var updateHotel = _service.UpdateHotel(hotel);
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
        [ProducesResponseType(typeof(ICollection<Hotels>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<Hotels> Get(int key)
        {
            var getOneHotel = _service.GetOneHotel(key);
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
        [ProducesResponseType(typeof(ICollection<Hotels>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<Hotels> GetAllHotels()
        {
            var getAllHotel = _service.GetAllHotels();
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
        [ProducesResponseType(typeof(ICollection<Hotels>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<Hotels> DeleteHotel(int key)
        {
            var deleteHotel = _service.DeleteHotel(key);
            if (deleteHotel == null)
            {
                return BadRequest("Unable to delete");
            }
            return Ok(deleteHotel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Hotels>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<Hotels> GetCityHotels(string city)
        {
            var getCityHotel = _service.GetHotelsByCity(city);
            if (getCityHotel == null)
            {
                return BadRequest("Unable to delete");
            }
            return Ok(getCityHotel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Hotels>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<Hotels> GetCountryHotels(string city)
        {
            var getCountryHotel = _service.GetHotelsByCountry(city);
            if (getCountryHotel == null)
            {
                return BadRequest("Unable to delete");
            }
            return Ok(getCountryHotel);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Hotels>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<Hotels> GetCountryAmenties(string amenties)
        {
            var getHotelAmenties = _service.GetHotelsByAmenties(amenties);
            if (getHotelAmenties == null)
            {
                return BadRequest("Unable to delete");
            }
            return Ok(getHotelAmenties);
        }
    }
}
