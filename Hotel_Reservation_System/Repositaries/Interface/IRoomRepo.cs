using Hotel_Reservation_System.DTO;
using Hotel_Reservation_System.Models;

namespace Hotel_Reservation_System.Repositaries.Interface
{
    public interface IRoomRepo
    {
        Task<IEnumerable<Room>> GetAllRoomAsync();
        Task<Room> GetRoomByIdAsync(int id);
        Task<Room> PostRoomAsync(CreateRoomDto room);
        Task<Room> PutRoomAsync(int id, Room room);
        Task<Room> DelRoomAsync(int id);
        Task<IEnumerable<Room>> GetRoomsByTypeAndCapacityAsync(string type, int capacity);


    }
}
