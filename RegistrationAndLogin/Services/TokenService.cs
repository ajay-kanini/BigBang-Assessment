﻿using Microsoft.IdentityModel.Tokens;
using RegistrationAndLogin.Interfaces;
using RegistrationAndLogin.Model.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RegistrationAndLogin.Services
{
    public class TokenService : IGenerateUserToken
    {
        private readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration configuration)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]));
        }
        public string GenerateUserToken(UserDTO userDTO)
        {
            string token = string.Empty;
            //User identity
            var claims = new List<Claim>
             {
               new Claim(JwtRegisteredClaimNames.NameId,userDTO.UserName)
             };
            //Signature algorithm
            var cred = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
            //Assembling the token details
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(3),
                SigningCredentials = cred
            };
            //Using the handler to generate the token
            var tokenHandler = new JwtSecurityTokenHandler();
            var myToken = tokenHandler.CreateToken(tokenDescription);
            token = tokenHandler.WriteToken(myToken);
            return token;
        }
            
    }
        
}

