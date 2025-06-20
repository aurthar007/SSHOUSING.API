using SSHOUSING.Domain.Entities;

public interface IUserRole
{
    List<UserRole> GetAllUserRole();
    UserRole GetUserRoleById(int id);
    UserRole GetUserRoleByUserId(int userId);
    bool Add(UserRole userRole);
    bool Update(UserRole userRole);
    bool Delete(int id);
}
