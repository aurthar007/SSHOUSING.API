using SSHOUSING.Domain.Entities;
using System.Collections.Generic;

namespace SSHOUSING.Domain.Interface
{
    public interface IMaintenanceRequest
    {
        List<MaintenanceRequest> GetAll();
        MaintenanceRequest GetById(int id);
        bool Add(MaintenanceRequest request);
        bool Update(MaintenanceRequest request);
        bool Delete(int id);
    }
}
