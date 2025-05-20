using SSHOUSING.Domain.Entities;

namespace SSHOUSING.Domain.Interface
{
    public interface IUser
    {
        bool AddUser(User user);
        User Login(string email, string password);

    }
}
