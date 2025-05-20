using SSHOUSING.Domain.Entities;
using SSHOUSING.Domain.Interface;

namespace SSHOUSING.Infrastucture.Repository
{
    public class UserRoleRepository : IUserRole
    {
        private readonly ApplicationDbContext _context;

        public UserRoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<UserRole> GetAll() => _context.UserRoles.ToList();

        public UserRole GetById(int id) => _context.UserRoles.Find(id);

        public bool Add(UserRole userRole)
        {
            _context.UserRoles.Add(userRole);
            _context.SaveChanges();
            return true;
        }

        public bool Update(UserRole userRole)
        {
            _context.UserRoles.Update(userRole);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var userRole = _context.UserRoles.Find(id);
            if (userRole == null) return false;
            _context.UserRoles.Remove(userRole);
            _context.SaveChanges();
            return true;
        }

       
    }
}
