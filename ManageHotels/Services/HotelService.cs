using ManageHotels.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using RegistrationAndLogin.Model;

namespace ManageHotels.Services
{
    public class HotelService
    {
        private readonly IRepo<int, Hotels> _repo;

        public HotelService(IRepo<int, Hotels> repo)
        {
            _repo = repo;
        }

        public ICollection<Hotels> GetHotelsByCity(string city)
        {
            var cityHotels = _repo.GetAll().ToList();
            return cityHotels.Where(c => c.LocationCity == city).ToList();
        }

        public ICollection<Hotels> GetHotelsByCountry(string country)
        {
            var countryHotels = _repo.GetAll().ToList();
            return countryHotels.Where(c => c.LocationCountry == country).ToList();
        }

        public ICollection<Hotels> GetHotelsByAmenties(string amenties)
        {
            var HotelAmenties = _repo.GetAll().ToList();
            return HotelAmenties.Where(c => c.Amenties == amenties).ToList();
        }
        public Hotels AddHotel(Hotels hotels)
        {
            return _repo.Add(hotels);
        }
        public Hotels UpdateHotel(Hotels hotels)
        {
            return _repo.Update(hotels);
        }
        public Hotels DeleteHotel(int key)
        {
            return _repo.Delete(key);
        }
        public Hotels GetOneHotel(int key)
        {
            return _repo.Get(key);
        }
        public ICollection<Hotels> GetAllHotels()
        {
            return _repo.GetAll().ToList();
        }

    }
}
