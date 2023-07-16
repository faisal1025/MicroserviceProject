using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Domain;

namespace UserService.UserDataAccess
{
    public class Repository : IRepository
    {
        private UserData userData;
        private IConfiguration config;
        public Repository(UserData userData, IConfiguration config)
        {
            this.userData = userData;
            this.config = config;
        }

        public OperationalResult<User> Delete(int Id)
        {
            userData.Delete(Id);
            return new OperationalResult<User>(true, "Account deleted Successfully");
        }

        public OperationalResult<User> Edit(int Id, User user)
        {
            userData.Update(Id, user);
            return new OperationalResult<User>(true, "Account is updated successfully");
        }

        public OperationalResult<IEnumerable<User>> GetAllUsers()
        {
            var users = userData.All();
            return new OperationalResult<IEnumerable<User>>(users, true, "All users fetched.");
        }

        public OperationalResult<User> Login(string Email, string Password)
        {
            OperationalResult<User> result = new OperationalResult<User>();
            var user = userData.Authenticate(Email, Password);

            if (user == null)
            {
                result.IsSuccess = false;
                result.text = "Credentials don't match.";
                return result;
            }

            var token = new JwtToken(config).GenerateToken(user);
            result.user = null;
            result.text = token;
            result.IsSuccess = true;
            return result;
        }

        public OperationalResult<User> Register(User user)
        {
            var usr = userData.Contains(user);
            if (usr != null)
            {
                return new OperationalResult<User>(usr, false, "Email already registered.");
            }
            usr = userData.Add(user);
            return new OperationalResult<User>(usr, true, "Data is stored successfully");
        }
    }
}
