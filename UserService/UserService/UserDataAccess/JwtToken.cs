using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain;

namespace UserService.UserDataAccess
{
    public class JwtToken
    {
        public string SecretKey { get; set; }
        public int TokenDuration { get; set; }
        private IConfiguration configuration;
        public JwtToken(IConfiguration configuration)
        {
            this.configuration = configuration;
            SecretKey = this.configuration.GetSection("jwtConfig").GetSection("key").Value;
            TokenDuration = Int32.Parse(this.configuration.GetSection("jwtConfig").GetSection("duration").Value);
        }

        public string GenerateToken(User userDTO)
        {
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.SecretKey));
            var Signature = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256); // Signature is made up of Key & SigningAlgorithm
            var Payload = new[]
            {
                new Claim("id", userDTO.Id.ToString()),
                new Claim("name", userDTO.Name),
                new Claim("email", userDTO.Email),
                new Claim("Role", userDTO.Role)
            };
            var JwtToken = new JwtSecurityToken( // JwtToken is made up of Signature, Payload
                issuer: "localhost",
                audience: "localhost",
                claims: Payload,
                expires: DateTime.Now.AddMinutes(this.TokenDuration),
                signingCredentials: Signature
            );

            return new JwtSecurityTokenHandler().WriteToken(JwtToken);
        }
    }
}
