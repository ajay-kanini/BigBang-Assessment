using ManageBooking.Intefaces;
using ManageBooking.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManageBooking.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IRepo<int, Booking> _repo;

        public BookingController(IRepo<int, Booking> repo)
        {
            _repo = repo;
        }

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

        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Booking>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<Booking> Get([FromBody] int key)
        {
            var getOneBooking = _repo.Get(key);
            if (getOneBooking == null)
            {
                return BadRequest("Unable to fetch");
            }
            return Ok(getOneBooking);
        }

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
    }
}
