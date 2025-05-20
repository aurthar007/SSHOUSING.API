using SSHOUSING.Domain.Interface;
using SSHOUSING.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SSHOUSING.Infrastucture.Repository
{
    public class RoleRepository : IRole
    {
        private readonly ApplicationDbContext _context;
        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool AddRole(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteRole(int Id)
        {
            var d = _context.Roles.Find(Id);
            _context.Roles.Remove(d);
            _context.SaveChanges();
            return true;
        }

        public List<Role> GetAllRole()
        {
            return _context.Roles.ToList();
        }

        public Role GetRoleById(int Id)
        {
            return _context.Roles.Find(Id);
        }

        public bool UpdateRole(Role role)
        {
            _context.Roles.Update(role);
            _context.SaveChanges();
            return true;
        }
    }
}