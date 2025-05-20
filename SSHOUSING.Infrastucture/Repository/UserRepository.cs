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

        public bool Create(User user)
        {
           
            var existingUser = _context.Users.FirstOrDefault(u => u.Email == user.Email);
            if (existingUser != null)
                return false; 

        
            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }

        public User GetByEmailAndPassword(string email, string password)
        {
            
            return _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}
