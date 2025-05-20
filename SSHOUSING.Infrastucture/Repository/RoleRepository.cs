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
            _context = context; // This is where the ApplicationDbContext is injected
        }

        public IEnumerable<Role> GetAll()
        {
            return _context.Roles.ToList(); // Fetching all roles from the database
        }

        public Role GetById(int id)
        {
            return _context.Roles.Find(id); // Finding role by ID in the database
        }

        public bool Create(Role role)
        {
            _context.Roles.Add(role); // Adding new role to the context
            _context.SaveChanges(); // Saving changes to the database
            return true;
        }

        public bool Update(Role role)
        {
            _context.Roles.Update(role); // Updating existing role
            _context.SaveChanges(); // Saving changes
            return true;
        }

        public bool Delete(int id)
        {
            var role = _context.Roles.Find(id); // Finding the role to delete
            if (role == null) return false;
            _context.Roles.Remove(role); // Removing the role from context
            _context.SaveChanges(); // Saving changes
            return true;
        }

        public List<Role> GetAllRole()
        {
            throw new NotImplementedException();
        }

        public Role GetRoleById(int Id)
        {
            throw new NotImplementedException();
        }

        public bool AddRole(Role role)
        {
            throw new NotImplementedException();
        }

        public bool UpdateRole(Role role)
        {
            throw new NotImplementedException();
        }

        public bool DeleteRole(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
