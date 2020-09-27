using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IUserRepositories:IDisposable
    {
        bool AddUser(User user);
        bool DeleteUser(User user);
        bool DeleteUser(Guid? Id);
        bool UpdateUser(User user);
        IEnumerable<User> GetAllUsers();
        User GetUserById(Guid? Id);
        void Save();

    }
}
