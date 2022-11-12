using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurlingServer
{
   public interface IUserService
    {
        List<User> GetAllUsers();
        void AddUser(string firstName, string lastName);
        void DeleteUser(int userId);
        void EditUser(User User);
    }
}
