using SSHOUSING.Domain.Entities;

namespace SSHOUSING.Domain.Interface
{
    public interface IUser
    {
        List<User> GetAll();
        User GetById(int id);
        bool Add(User user);
        bool Update(User user);
        bool Delete(int id);
    }
}
