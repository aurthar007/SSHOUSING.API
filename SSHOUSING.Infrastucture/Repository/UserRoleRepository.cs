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

        public List<UserRole> GetAllUserRole()
        {
            return _context.UserRoles.ToList();
        }

        public UserRole GetUserRoleById(int Id)
        {
            return _context.UserRoles.Find(Id);
        }
    }
}