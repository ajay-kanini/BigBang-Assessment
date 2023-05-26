using ManageRooms.Context;
using ManageRooms.Interfaces;
using ManageRooms.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;

namespace ManageRooms.Services
{      
    public class RoomsRepo : IRepo<int, Rooms>
    {
        private readonly RoomsContext _context;

        public RoomsRepo(RoomsContext context)
        {
            _context = context; 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Rooms Add(Rooms item)
        {
            try
            {
                _context.Rooms.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        public Rooms Delete(int Key)
        {
            var room = Get(Key);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                _context.SaveChanges();
                return room;
            }
            return null;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        public Rooms Get(int Key)
        {
            var room = Get(Key);
            if (room != null)
            {
                return room;
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ICollection<Rooms> GetAll()
        {
            return _context.Rooms.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Rooms Update(Rooms item)
        {
            var rooms = Get(item.Id);
            if (rooms != null)
            {
              rooms.Id = item.Id;
              rooms.RoomType = item.RoomType;
              rooms.RoomPrice = item.RoomPrice;
              rooms.NumberofRoom = item.NumberofRoom;
              rooms.AvailableRooms = item.AvailableRooms; 
              rooms.HotelId = item.Id;                
            }
            return null;
        }
    }
}
