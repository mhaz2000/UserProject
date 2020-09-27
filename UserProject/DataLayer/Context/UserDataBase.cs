using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataLayer
{
    public class UserDataBase : DbContext
    {
        public UserDataBase()
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
