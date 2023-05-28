using System.ComponentModel.DataAnnotations;

namespace Hotel_Reservation_System.Models
{
    public class Hotel
    {


        [Key]
        public int Hotel_Id { get; set; }

        [Required]
        public string? Hotel_Name { get; set; }

        public string? Location { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string? Contact_Number { get; set; }

        public virtual ICollection<Room>? Rooms { get; set; }
    }
}
