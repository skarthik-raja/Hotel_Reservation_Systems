using Hotel_Reservation_System.Data;
using Hotel_Reservation_System.DTO;
using Hotel_Reservation_System.Models;
using Hotel_Reservation_System.Repositaries.Interface;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Reservation_System.Repositaries
{
    public class RoomRepo : IRoomRepo
    {


        private readonly HotelDbcontext _dbcontext;

        public RoomRepo (HotelDbcontext context)
        {
            this._dbcontext = context;
        }
        public async Task<Room> DelRoomAsync(int id)
        {
            try
            {
                Room del = await _dbcontext.Rooms.FirstOrDefaultAsync(x => x.Room_Id == id);
                _dbcontext.Rooms.Remove(del);
                await _dbcontext.SaveChangesAsync();
                return del;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Room>> GetAllRoomAsync()
        {
            try
            {
                return await _dbcontext.Rooms.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Room> GetRoomByIdAsync(int id)
        {
            try
            {
                return await _dbcontext.Rooms.FirstOrDefaultAsync(x => x.Room_Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Room> PostRoomAsync(CreateRoomDto room)
        {
            try
            {
                var newRoom = new Room
                {
                    Room_Number = room.RoomNumber,
                    Type = room.Type,
                    Capacity = room.Capacity,
                    Hotel_Id = room.HotelId,

                };
                _dbcontext.Rooms.Add(newRoom);
                await _dbcontext.SaveChangesAsync();
                return newRoom;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Room> PutRoomAsync(int id, Room room)
        {
            try
            {
                _dbcontext.Entry(room).State = EntityState.Modified;
                await _dbcontext.SaveChangesAsync();
                return room;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Room>> GetRoomsByTypeAndCapacityAsync(string type, int capacity)
        {
            try
            {
                return await _dbcontext.Rooms
                    .Where(room => room.Type == type && room.Capacity == capacity)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

