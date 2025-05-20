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

        public bool Add(State state)
        {
            throw new NotImplementedException();
        }

        public bool Add(User user)
        {
            throw new NotImplementedException();
        }

        public bool AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<State> GetAll()
        {
            throw new NotImplementedException();
        }

        public State GetById(int id)
        {
            throw new NotImplementedException();
        }

        public User Login(string email, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }

        public bool Update(State state)
        {
            throw new NotImplementedException();
        }

        public bool Update(User user)
        {
            throw new NotImplementedException();
        }

        List<User> IUser.GetAll()
        {
            throw new NotImplementedException();
        }

        User IUser.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}