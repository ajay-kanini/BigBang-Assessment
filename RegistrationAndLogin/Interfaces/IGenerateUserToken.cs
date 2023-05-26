using RegistrationAndLogin.Model.DTO;

namespace RegistrationAndLogin.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IGenerateUserToken
    {
        public string GenerateUserToken(UserDTO userDTO);  
    }
}
