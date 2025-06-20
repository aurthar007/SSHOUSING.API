using SSHOUSING.Domain.Entities;
using System.Collections.Generic;

namespace SSHOUSING.Domain.Interface
{
    public interface IUser
    {
        bool AddUser(User user);
        User Login(string email, string password);
        List<User> GetAllUser();
    }
}
