using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Repository : IUserRepositories
    {
        protected UserDataBase db = new UserDataBase();

        /// <summary>
        /// Add new User into database.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool AddUser(User user)
        {
            try
            {
                db.Users.Add(user);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Delete an user from database.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool DeleteUser(User user)
        {
            try
            {
                db.Entry(user).State = System.Data.Entity.EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Delete an User from database by its id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DeleteUser(Guid? Id)
        {
            try
            {
                var Res = GetUserById(Id);
                DeleteUser(Res);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }

        /// <summary>
        /// Get all users.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> GetAllUsers()
        {
            return db.Users;
        }

        /// <summary>
        /// Get an User by its Id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public User GetUserById(Guid? Id)
        {
            return db.Users.Find(Id);
        }

        /// <summary>
        /// Save all changes.
        /// </summary>
        public void Save()
        {
            db.SaveChanges();
        }

        public bool UpdateUser(User user)
        {
            try
            {
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
