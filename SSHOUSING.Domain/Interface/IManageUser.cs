using SSHOUSING.Domain.Entities;
using System.Collections.Generic;

namespace SSHOUSING.Domain.Interface
{
    public interface IManageUser
    {
        IEnumerable<ManageUsers> GetUsersByRole(string role);
        bool AddUser(ManageUsers user);
    }
}
