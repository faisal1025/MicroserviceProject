using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Domain;

namespace UserService.UserDataAccess
{
    public class UserData
    {
        private IList<User> users = new List<User>();

        public IEnumerable<User> All()
        {
            return users;
        }
        public User Add(User user)
        {
            var cnt = users.Count();
            user.Id = cnt == 0 ? 1 : users[cnt-1].Id + 1;
            users.Add(user);
            Console.WriteLine(users.Count());
            return user;
        }

        public void Delete(int Id)
        {
            var user = users.Where<User>(u => u.Id == Id).FirstOrDefault<User>();
            users.Remove(user);
        }

        public User GetById(int Id)
        {
            return users.FirstOrDefault<User>(u => u.Id == Id);
        }

        public void Update(int Id, User user)
        {
            user.Id = Id;
            this.Delete(Id);
            this.Add(user);
        }
        public User Authenticate(string Email, string Password)
        {
            var user = users.FirstOrDefault<User>(u => u.Email == Email && u.Password == Password);
            return user;
        }
        public User Contains(User user)
        {
            return users.FirstOrDefault<User>(u => u.Email == user.Email);
        }
    }
}
