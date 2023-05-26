using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Runtime.CompilerServices;

namespace RegistrationAndLogin.Model
{
    public class Hotels
    {
        [Key]
        [Column("Hotel Id")]
        public int Id { get; set; }

        [Column("Hotel Name")]
        public string? HotelName { get; set; }

        [Column("City Location")]
        public string? LocationCity { get; set; }

        [Column("Country Loacation")]
        public string? LocationCountry { get; set; }

        [Column("Amenties")]
        public string? Amenties { get; set; }
    }
}
