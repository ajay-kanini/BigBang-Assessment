using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManageRooms.Models
{
    public class Rooms
    {
        [Key]
        [Column("Room Id")]
        public int Id { get; set; }

        [Column("Room Type")]
        public string RoomType { get; set; }

        [Column("Number of rooms")]
        public string NumberofRoom { get; set;}

        [Column("Availability Status  Yes or No")]
        public string AvailablityStatus { get; set; }

        [Column("Amenties")]
        public string Amenties { get; set; }

        [Column("Room Price")]
        public double RoomPrice { get; set; }

        //Will be connected as a foreign key reference to Hotel API
        public int HotelId { get; set; }
    }
}
