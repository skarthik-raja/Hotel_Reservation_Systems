using Hotel_Reservation_System.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Reservation_System.Data
{
    public class HotelDbcontext: DbContext
    {

        public HotelDbcontext(DbContextOptions<HotelDbcontext> options) : base(options)
        {

        }
        public DbSet<User> users { get; set; }
        public DbSet<Hotel> hotels { get; set; }

        public DbSet<Room> Rooms { get; set; }
    }
}
