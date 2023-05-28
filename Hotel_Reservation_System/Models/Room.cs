using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Hotel_Reservation_System.Models
{
    public class Room
    {
        [Key]
        public int? Room_Id { get; set; }


        public string? Room_Number { get; set; }

        public string? Type { get; set; }

        [Range(1, 10)]
        public int? Capacity { get; set; }

        [JsonIgnore]

        public Hotel? Hotel { get; set; }
        public int Hotel_Id { get; set; }
    }
}
