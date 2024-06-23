using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Proiect.Database.Entities;

namespace Proiect.Core.Services
{
    public class AuthService
    {
        private readonly string _securityKey;

        public AuthService(IConfiguration config)
        {
            _securityKey = config["Jwt:SecurityKey"];
            if (string.IsNullOrEmpty(_securityKey))
            {
                throw new ArgumentNullException(nameof(_securityKey), "JWT Security Key cannot be null or empty.");
            }
        }

        public string GetToken(User user, string role)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_securityKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("role", role),
                new Claim("userId", user.UserId.ToString()),
                new Claim("username", user.Email)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = "Backend",
                Audience = "Frontend",
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = credentials
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }

        public bool ValidateToken(string tokenString)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_securityKey));

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = "Backend",
                ValidateAudience = true,
                ValidAudience = "Frontend",
                ValidateLifetime = true,
                IssuerSigningKey = key,
                ValidateIssuerSigningKey = true
            };

            try
            {
                jwtTokenHandler.ValidateToken(tokenString, tokenValidationParameters, out SecurityToken validatedToken);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Token validation failed: {ex.Message}");
                return false;
            }
        }

        public byte[] GenerateSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }

        public string HashPassword(string password, byte[] salt)
        {
            var bytes = KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 1000,
                numBytesRequested: 256 / 8);

            return Convert.ToBase64String(bytes);
        }
    }
}
