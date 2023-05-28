using ManageRooms.Interfaces;
using ManageRooms.Models;

namespace ManageRooms.Services
{
    public class RoomsService
    {
        private readonly IRepo<int, Rooms> _repo;

        public RoomsService(IRepo<int, Rooms> repo)
        {
            _repo = repo;
        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="hotelId"></param>
       /// <returns></returns>
        public ICollection<Rooms> RoomsofHotels(int hotelId)
        {
            var rooms = _repo.GetAll().Where(x => x.HotelId == hotelId);
            return rooms.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        public ICollection<Rooms> CountAvailableRooms(int hotelId)
        {
            var rooms = RoomsofHotels(hotelId).ToList();
            return rooms.Where(x => x.AvailablityStatus == "Yes" || x.AvailablityStatus == "yes").ToList();
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="amenities"></param>
       /// <returns></returns>
        public ICollection<Rooms> AvailableAmenties(string amenities)
        {
            var rooms = _repo.GetAll().ToList();
            return rooms.Where(x => x.Amenties.Contains(amenities)).ToList();

        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="maximumPrice"></param>
       /// <param name="minimumPrice"></param>
       /// <returns></returns>
        public ICollection<Rooms> PriceRange(double maximumPrice, double minimumPrice)
        {
            var rooms = _repo.GetAll().ToList();
            return rooms.Where(x => x.RoomPrice >= maximumPrice && x.RoomPrice <= minimumPrice).ToList();

        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rooms"></param>
        /// <returns></returns>
        public Rooms AddRooms(Rooms rooms)
        {
            return _repo.Add(rooms);
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="rooms"></param>
       /// <returns></returns>
        public Rooms UpdateRooms(Rooms rooms)
        {
            return _repo.Update(rooms); 
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        public Rooms DeleteRooms(int id)
        {
            return _repo.Delete(id);  
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        public Rooms GetOneRoom(int id)
        {
            return _repo.Get(id);
        }

       /// <summary>
       /// 
       /// </summary>
       /// <returns></returns>
        public ICollection<Rooms> GetAllRooms()
        {
            return _repo.GetAll();
        }
    }
}
