using ManageBooking.Intefaces;
using ManageBooking.Model;

namespace ManageBooking.Services
{
    public class BookingService
    {
        private IRepo<int, Booking> _repo;

        public BookingService(IRepo<int, Booking> repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ICollection<Booking> UserBookingDetails(int id)
        {
            var bookings = _repo.GetAll();
            return bookings.Where(x => x.UserId == id).ToList();
        }

    }
}
