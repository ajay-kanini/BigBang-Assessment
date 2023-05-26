using ManageHotels.Context;
using ManageHotels.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RegistrationAndLogin.Model;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace HotelAPI.Services
{
    /// <summary>
    /// Repository class that implemented functions which are implemented in the IRepo
    /// </summary>
    public class HotelRepo : IRepo<int, Hotels> 
    {
        private readonly HotelsContext _hotelsContext;

        public HotelRepo(HotelsContext hotelsContext)
        {
            _hotelsContext = hotelsContext;
        }

        public Hotels Add(Hotels item)
        {
            try
            {
                _hotelsContext.Hotel.Add(item);
                _hotelsContext.SaveChanges();
                return item;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return null;
        }

        public Hotels Delete(int key)
        {
            var hotel = Get(key);
            if (hotel != null)
            {
                _hotelsContext.Hotel.Remove(hotel);
                _hotelsContext.SaveChanges();
                return hotel;
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Hotels Get(int key)
        {
            var hotel = _hotelsContext.Hotel.FirstOrDefault(b => b.Id == key);
            if (hotel == null)
            {
                return null;
            }
            return hotel;
        }

        public ICollection<Hotels> GetAll()
        {
            return _hotelsContext.Hotel.ToList();
        }

        public Hotels Update(Hotels item)
        {
            var Hotel = Get(item.Id);
            if (Hotel != null)
            {
                Hotel.HotelName = item.HotelName;
                Hotel.Price = item.Price;   
                Hotel.LocationCity = item.LocationCity; 
                Hotel.LocationCountry=item.LocationCountry;
                Hotel.Amenties = item.Amenties; 
            }
            return null;
        }
    }
}