using AirBench.Data;
using AirBench.Models;
using System.Collections.Generic;
using System.Linq;

namespace AirBench.Repositories
{
    public class UserRepository
    {
        private Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public User GetLoggedInUser(string email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email);
        }

        public void Insert(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}