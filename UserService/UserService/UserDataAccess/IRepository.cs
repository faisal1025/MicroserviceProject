using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Domain;

namespace UserService.UserDataAccess
{
    public interface IRepository
    {
        OperationalResult<IEnumerable<User>> GetAllUsers();
        OperationalResult<User> Register(User user);
        OperationalResult<User> Login(string Email, string Password);
        OperationalResult<User> Delete(int Id);
        OperationalResult<User> Edit(int Id, User user);
    }
}
