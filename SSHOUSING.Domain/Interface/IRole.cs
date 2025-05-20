using SSHOUSING.Domain.Entities;

namespace SSHOUSING.Domain.Interface
{
    public interface IRole
    {
        IEnumerable<Role> GetAll();
        Role GetById(int id);
        bool Create(Role role);
        bool Update(Role role);
        bool Delete(int id);
    }
}
