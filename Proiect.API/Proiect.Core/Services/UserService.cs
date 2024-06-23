using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proiect.Database.Dtos.Request;
using Proiect.Database.Entities;
using Proiect.Database.Repositories;

namespace Proiect.Core.Services
{
    public class UserService
    {
        public AuthService authService { get; set; }
        public UsersRepository usersRepository { get; set; }

        public UserService(AuthService authService, UsersRepository usersRepository)
        {
            this.authService = authService;
            this.usersRepository = usersRepository;
        }

        public void Register(RegisterRequest registerData)
        {
            if (registerData == null)
            {
                throw new ArgumentNullException(nameof(registerData), "Registration data cannot be null.");
            }

            var salt = authService.GenerateSalt();
            var hashedPassword = authService.HashPassword(registerData.Password, salt);

            var user = new User
            {
                FirstName = registerData.FirstName,
                LastName = registerData.LastName,
                Email = registerData.Email,
                Password = hashedPassword,
                PasswordSalt = Convert.ToBase64String(salt),
                DateCreated = DateTime.UtcNow
            };

            Console.WriteLine($"Registering User: {user.Email}");
            Console.WriteLine($"Generated Salt: {Convert.ToBase64String(salt)}");
            Console.WriteLine($"Hashed Password: {hashedPassword}");

            usersRepository.Add(user);
        }




        public string Login(LoginRequest payload)
        {
            var user = usersRepository.GetByEmail(payload.Email);
            if (user == null)
            {
                Console.WriteLine("User not found.");
                return null;
            }

            Console.WriteLine($"User Found: {user.Email}");
            Console.WriteLine($"Stored Salt: {user.PasswordSalt}");
            Console.WriteLine($"Stored Hashed Password: {user.Password}");

            var salt = Convert.FromBase64String(user.PasswordSalt);
            var hashedPassword = authService.HashPassword(payload.Password, salt);

            Console.WriteLine($"Hashed Password (Login): {hashedPassword}");
            Console.WriteLine($"Salt (Login): {salt}");

            if (hashedPassword != user.Password)
            {
                Console.WriteLine("Invalid password.");
                return null;
            }

            var role = GetRole(user); // Ensure this method correctly retrieves the user's role.
            return authService.GetToken(user, role);
        }



        private string GetRole(User user)
        {
            if (user.Email == "a@")
            {
                return "Admin";
            }
            else
            {
                return "User";
            }
        }
    }
}
