using SSHOUSING.Domain.Entities;

public interface IUserRole
{
    IEnumerable<UserRole> GetAll();
    UserRole GetById(int id);
    bool Add(UserRole userRole);
    bool Update(UserRole userRole);
    bool Delete(int id);
}
