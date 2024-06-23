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
        public UserService(
            AuthService authService,
            UsersRepository usersRepository)
        {
            this.authService = authService;
            this.usersRepository = usersRepository;
        }

        public void Register(RegisterRequest registerData)
        {
            if (registerData == null)
            {
                return;
            }

            var salt = authService.GenerateSalt();
            var hashedPassword = authService.HashPassword(registerData.Password, salt);

            var user = new User();
            user.FirstName = registerData.FirstName;
            user.LastName = registerData.LastName;
            user.Email = registerData.Email;
            user.Password = hashedPassword;
            user.PasswordSalt = Convert.ToBase64String(salt);
            user.DateCreated = DateTime.UtcNow;

            usersRepository.Add(user);
        }

        public string Login(LoginRequest payload)
        {
            var user = usersRepository.GetByEmail(payload.Email);

            if (authService.HashPassword(payload.Password, Convert.FromBase64String(user.PasswordSalt)) == user.Password)
            {
                var role = GetRole(user);

                return authService.GetToken(user, role);
            }
            else
            {
                return null;
            }
        }

        private string GetRole(User user)
        {
            if (user.Email == "alex@gmail.com")
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
