using Microsoft.EntityFrameworkCore;
using RegistrationAndLogin.Context;
using RegistrationAndLogin.Interfaces;
using RegistrationAndLogin.Model;
using System.Diagnostics;

namespace RegistrationAndLogin.Services
{
    public class UserRepo : IBaseRepo<string, Users>
    {
        private readonly DatabaseContext _databaseContext;

        public UserRepo(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext; 
        }
        public Users Add(Users item)
        {
            try
            {
                _databaseContext.User.Add(item);
                _databaseContext.SaveChanges();
                return item;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(item);
            }
            return null;
        }

        public Users Get(string key)
        {
            var user = _databaseContext.User.FirstOrDefault(u => u.UserName == key);
            return user;
        }
    }
}
