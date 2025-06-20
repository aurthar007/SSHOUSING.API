using SSHOUSING.Domain.Entities;
using SSHOUSING.Domain.Interface;
using System.Collections.Generic;
using System.Linq;

namespace SSHOUSING.Infrastucture.Repository
{
    public class UserRoleRepository : IUserRole
    {
        private readonly ApplicationDbContext _context;

        public UserRoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<UserRole> GetAllUserRole()
        {
            return _context.UserRoles.ToList();
        }

        public UserRole GetUserRoleById(int id)
        {
            return _context.UserRoles.Find(id);
        }

        // ✅ NEW: Get UserRole by UserId (required for login)
        public UserRole GetUserRoleByUserId(int userId)
        {
            return _context.UserRoles.FirstOrDefault(ur => ur.UserId == userId);
        }

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
