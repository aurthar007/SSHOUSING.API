using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHOUSING.Domain.Interface
{
    using SSHOUSING.Domain.Entities;
    using System.Collections.Generic;

    public interface IUser
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        bool Create(User user);
        bool Update(User user);
        bool Delete(int id);
    }
}