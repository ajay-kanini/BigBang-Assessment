using ManageBooking.Model;
using Microsoft.EntityFrameworkCore;

namespace ManageBooking.Context
{
    public class BookingContext : DbContext
    {
        public BookingContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Booking> Bookings { get; set; }
    }
}
