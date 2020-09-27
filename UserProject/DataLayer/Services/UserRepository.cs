using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UserRepository:Repository
    {
        /// <summary>
        /// Get Users by his/her fullnames or natinal codes.
        /// </summary>
        /// <param name="SearchStr"></param>
        /// <returns></returns>
        public IEnumerable<User> GetUsersByNameOrNatinaolCode(string SearchStr)
        {
            List<User> users= db.Users.Where(w => (w.Name + " " + w.Family).Contains(SearchStr) || w.NationalCode == SearchStr).ToList();
            return users;
        }
    }
}
