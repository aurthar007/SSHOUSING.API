using SSHOUSING.Domain.Entities;

public interface IUserRole
{
    List<UserRole> GetAllUserRole();
    UserRole GetUserRoleById(int Id);
}
