using Hotel_Reservation_System.DTO;
using Hotel_Reservation_System.Models;

namespace Hotel_Reservation_System.Repositaries.Interface
{
    public interface IHotelRepo
    {

        Task<IEnumerable<Hotel>> GetAllHotelsAsync();
        Task<Hotel> GetHotelByIdAsync(int id);
        Task<Hotel> PostHotelsAsync(CreateHotelDto hotel);
        Task<Hotel> PutHotelAsync(int id, Hotel hotel);
        Task<Hotel> DelHotelsAsync(int id);
        Task<string> GetRoomCountMessageByHotelIdAsync(int hotelId);
        Task<string> GetPhoneNumberByAddressAsync(string address);


        Task<Hotel> GetByIdAsync(int id);
        
    }
}

