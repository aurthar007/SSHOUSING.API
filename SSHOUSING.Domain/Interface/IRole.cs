using SSHOUSING.Domain.Entities;

namespace SSHOUSING.Domain.Interface
{
    public interface IRole
    {
        List<Role> GetAllRole();
        Role GetRoleById(int Id);
        bool AddRole(Role role);
        bool UpdateRole(Role role);
        bool DeleteRole(int Id);
    }
}
