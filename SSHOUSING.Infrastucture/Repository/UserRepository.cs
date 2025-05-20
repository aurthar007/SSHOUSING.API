using SSHOUSING.Domain.Entities;
using SSHOUSING.Domain.Interface;
using System.Linq;

namespace SSHOUSING.Infrastucture.Repository
{
    public class UserRepository : IUser
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }

        public User Login(string email, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}