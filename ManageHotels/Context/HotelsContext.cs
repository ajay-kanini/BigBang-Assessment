using Microsoft.EntityFrameworkCore;
using RegistrationAndLogin.Model;

namespace ManageHotels.Context
{
    public class HotelsContext : DbContext
    {
        public HotelsContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Hotels> Hotel { get; set; }    
    }
}
