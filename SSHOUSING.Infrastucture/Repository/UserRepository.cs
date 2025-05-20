

using SSHOUSING.Domain.Interface;

namespace SSHOUSING.Infrastucture.Repository
{
    public class UserRepository : IUser
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll() => _context.Users.ToList();

        public User GetById(int id) => _context.Users.Find(id);

        public bool Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }

        public bool Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return false;
            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        }
    }
}
