using ManageBooking.Context;
using ManageBooking.Intefaces;
using ManageBooking.Model;
using System.Diagnostics;

namespace ManageBooking.Services
{
    public class BookingRepo : IRepo<int, Booking>
    {
        private readonly BookingContext _context;

        public BookingRepo(BookingContext context)
        {
            _context = context;
        }
        public Booking Add(Booking item)
        {
            try
            {
                _context.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception ex) 
            {
                Debug.WriteLine(ex);    
            }
            return null;
        }

        public Booking Delete(int Key)
        {
            var bookRoom = Get(Key);
            if(bookRoom != null)
            {
                _context.Remove(bookRoom);
                _context.SaveChanges();
                return bookRoom;
            }
            return null;
        }

        public Booking Get(int Key)
        {
            var bookRoom = Get(Key);
            if(bookRoom != null)
            {
                return bookRoom;
            }
            return null;
        }

        public ICollection<Booking> GetAll()
        {
            return _context.Bookings.ToList();
        }

        public Booking Update(Booking item)
        {
            var bookRoom = Get(item.Id);
            if (bookRoom != null)
            {
                bookRoom.Id = item.Id;
                bookRoom.RoomId= item.RoomId;
                bookRoom.UserId = item.UserId;
                bookRoom.HotelID = item.HotelID;
                bookRoom.CheckinDate = item.CheckinDate;
                bookRoom.CheckoutDate = item.CheckoutDate;
                bookRoom.BillAmount = item.BillAmount;
            }
            return null;
        }
    }
}
