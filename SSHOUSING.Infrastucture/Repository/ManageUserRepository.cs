using SSHOUSING.Domain.Entities;
using SSHOUSING.Domain.Interface;
using SSHOUSING.Infrastucture;
using System.Collections.Generic;
using System.Linq;

namespace SSHOUSING.Infrastructure.Repository
{
    public class ManageUserRepository : IManageUser
    {
        private readonly ApplicationDbContext _context;

        public ManageUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ManageUsers> GetUsersByRole(string role)
        {
            return _context.ManageUsers
                .Where(u => u.Role.ToLower() == role.ToLower())
                .ToList();
        }

        public ManageUsers AddUser(ManageUsers user)
        {
            _context.ManageUsers.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
}
