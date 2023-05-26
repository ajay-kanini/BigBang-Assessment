using ManageRooms.Models;
using Microsoft.EntityFrameworkCore;

namespace ManageRooms.Context
{
    public class RoomsContext : DbContext 
    {
        public RoomsContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Rooms> Rooms { get; set; }
    }
}
