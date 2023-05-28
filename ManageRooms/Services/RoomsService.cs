﻿using ManageRooms.Interfaces;
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
        public ICollection<Rooms> RoomsofHotels(int hotelId)
        {
            var rooms = _repo.GetAll().Where(x => x.HotelId == hotelId);
            return rooms.ToList();
        }

        public ICollection<Rooms> CountAvailableRooms(int hotelId)
        {
            var rooms = RoomsofHotels(hotelId).ToList();
            return rooms.Where(x => x.AvailablityStatus == "Yes" || x.AvailablityStatus == "yes").ToList();
        }

        public ICollection<Rooms> AvailableAmenties(string amenities)
        {
            var rooms = _repo.GetAll().ToList();
            return rooms.Where(x => x.Amenties.Contains(amenities)).ToList();

        }
        public ICollection<Rooms> PriceRange(int maximumPrice, int minimumPrice)
        {
            var rooms = _repo.GetAll().ToList();
            return rooms.Where(x => x.RoomPrice <= maximumPrice && x.RoomPrice >= minimumPrice).ToList();

        }
    }
}