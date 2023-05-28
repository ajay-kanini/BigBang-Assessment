using ManageBooking.Intefaces;
using ManageBooking.Model;
using ManageBooking.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ManageBooking.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IRepo<int, Booking> _repo;
        private readonly BookingService _service;

        public BookingController(IRepo<int, Booking> repo, BookingService service)
        {
            _service = service;
            _repo = repo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Booking"></param>
        /// <returns></returns>
        /// 
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ProducesResponseType(typeof(ICollection<Booking>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Booking> AddBooking([FromBody] Booking Booking)
        {
            var addBooking = _repo.Add(Booking);
            if (addBooking == null)
            {
                return BadRequest("Unable to add");
            }
            return Created("Welcome", addBooking);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Booking"></param>
        /// <returns></returns>
        /// 
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ProducesResponseType(typeof(ICollection<Booking>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<Booking> Update([FromBody] Booking Booking)
        {
            var updateBooking = _repo.Update(Booking);
            if (updateBooking == null)
            {
                return BadRequest("Unable to update");
            }
            return Ok(updateBooking);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Booking>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<Booking> Get(int key)
        {
            var getOneBooking = _repo.Get(key);
            if (getOneBooking == null)
            {
                return BadRequest("Unable to fetch");
            }
            return Ok(getOneBooking);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Booking>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<Booking> GetAll()
        {
            var getAllBooking = _repo.GetAll();
            if (getAllBooking == null)
            {
                return BadRequest("Unable to fetch");
            }
            return Ok(getAllBooking);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        /// 
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Booking>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<Booking> Delete(int key)
        {
            var deleteBooking = _repo.Delete(key);
            if (deleteBooking == null)
            {
                return BadRequest("Unable to delete");
            }
            return Ok(deleteBooking);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Booking>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<Booking> UserBooking(int id)
        {
            var bookingDetails = _service.UserBookingDetails(id);
            if (bookingDetails== null)
            {
                return BadRequest("Unable to fetch");
            }
            return Ok(bookingDetails);
        }
    }
}
