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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public ICollection<Hotels> GetHotelsByCity(string city)
        {
            var cityHotels = _repo.GetAll().ToList();
            return cityHotels.Where(c => c.LocationCity == city).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        public ICollection<Hotels> GetHotelsByCountry(string country)
        {
            var countryHotels = _repo.GetAll().ToList();
            return countryHotels.Where(c => c.LocationCountry == country).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="amenties"></param>
        /// <returns></returns>
        public ICollection<Hotels> GetHotelsByAmenties(string amenties)
        {
            var HotelAmenties = _repo.GetAll().ToList();
            return HotelAmenties.Where(c => c.Amenties == amenties).ToList();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hotels"></param>
        /// <returns></returns>
        public Hotels AddHotel(Hotels hotels)
        {
            return _repo.Add(hotels);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hotels"></param>
        /// <returns></returns>
        public Hotels UpdateHotel(Hotels hotels)
        {
            return _repo.Update(hotels);
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Hotels DeleteHotel(int key)
        {
            return _repo.Delete(key);
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Hotels GetOneHotel(int key)
        {
            return _repo.Get(key);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ICollection<Hotels> GetAllHotels()
        {
            return _repo.GetAll().ToList();
        }

    }
}
