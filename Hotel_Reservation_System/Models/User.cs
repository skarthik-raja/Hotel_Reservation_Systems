using System.ComponentModel.DataAnnotations;

namespace Hotel_Reservation_System.Models
{
    public class User
    {

        [Key]
        public int User_Id { get; set; }

        public string? User_Name { get; set; }

        public string? User_Email { get; set; }

        public string? Password { get; set; }
    }
}
