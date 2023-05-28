using Hotel_Reservation_System.Data;
using Hotel_Reservation_System.DTO;
using Hotel_Reservation_System.Models;
using Hotel_Reservation_System.Repositaries.Interface;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Reservation_System.Repositaries
{
    public class HotelRepo : IHotelRepo
    {

        private readonly HotelDbcontext _dbContext;


        public HotelRepo (HotelDbcontext context)
        {
            this._dbContext = context;
        }
        public async Task<Hotel> DelHotelsAsync(int id)
        {
            try
            {
                Hotel del = await _dbContext.hotels.FirstOrDefaultAsync(x => x.Hotel_Id == id);
                _dbContext.hotels.Remove(del);
                await _dbContext.SaveChangesAsync();
                return del;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Hotel>> GetAllHotelsAsync()
        {
            try
            {
                return await _dbContext.hotels.Include(x => x.Rooms).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Hotel> GetByIdAsync(int id)
        {
            return await _dbContext.hotels
                .Join(_dbContext.Rooms, t1 => t1.Hotel_Id, t2 => t2.Hotel_Id, (t1, t2) => t1)
                .FirstOrDefaultAsync(hotel => hotel.Hotel_Id == id);
        }

        public async Task<string> GetRoomCountMessageByHotelIdAsync(int hotelId)
        {
            try
            {
                int roomCount = await _dbContext.Rooms
                    .CountAsync(room => room.Hotel_Id == hotelId);

                string message = $"Hotel id {hotelId} has {roomCount} room{(roomCount != 1 ? "s" : "")} available";

                return message;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> GetPhoneNumberByAddressAsync(string address)
        {
            try
            {
                Hotel hotel = await _dbContext.hotels
                    .FirstOrDefaultAsync(h => h.Location == address);

                if (hotel != null)
                {
                    string hotelInfo = $"This is {hotel.Hotel_Name}, with phone number {hotel.Contact_Number} at {hotel.Location}";
                    return hotelInfo;
                }

                return $"No hotel found at the address: {address}";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<Hotel> GetHotelByIdAsync(int id)
        {
            try
            {
                return await _dbContext.hotels.Include(x => x.Rooms).FirstOrDefaultAsync(x => x.Hotel_Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Hotel> PostHotelsAsync(CreateHotelDto hotel)
        {
            try
            {

                var newHotel = new Hotel
                {
                    Hotel_Name = hotel.Name,
                    Location = hotel.Address,
                    Contact_Number = hotel.PhoneNumber

                };
                _dbContext.hotels.Add(newHotel);
                await _dbContext.SaveChangesAsync();
                return newHotel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<Hotel> PutHotelAsync(int id, Hotel hotel)
        {
            try
            {
                _dbContext.Entry(hotel).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return hotel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

