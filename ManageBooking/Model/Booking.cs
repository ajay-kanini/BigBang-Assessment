using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManageBooking.Model
{
    public class Booking
    {
        [Key]
        [Column("Booking Id")]
        public int Id { get; set; }

        [Column("User Id")]
        public int UserId { get; set; }

        [Column("Room Id")]
        public int RoomId { get; set; }

        [Column("Hotel Id")]
        public int HotelID { get; set; }

        [Column("Check-in Date")]
        public DateTime CheckinDate { get; set; }

        [Column("Check-out Date")]
        public DateTime CheckoutDate { get; set; }

        [Column("Bill Amount")]
        public double? BillAmount { get; set; }

    }
}
