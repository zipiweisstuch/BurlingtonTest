using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurlingServer
{

    public class UserService : IUserService
    {
        private BurlingtonContext db = new BurlingtonContext();
        
        /// <summary>
        /// Add User
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        void IUserService.AddUser(string firstName, string lastName)
        {
            try
            {
                var newUser = new User() { FirstName = firstName, LastName = lastName };
                db.Users.Add(newUser);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
        }

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="userId"></param>
        void IUserService.DeleteUser(int userId)
        {
            try
            {
                User user = db.Users.Find(userId);
                db.Users.Remove(user);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
        }

        /// <summary>
        /// Edit User
        /// </summary>
        /// <param name="user"></param>
        void IUserService.EditUser(User user)
        {
            try
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
        }

        /// <summary>
        /// Get users list
        /// </summary>
        /// <returns></returns>
        List<User> IUserService.GetAllUsers()
        {
            try
            {
                return db.Users.ToList();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
            return null;
        }

    }
}
