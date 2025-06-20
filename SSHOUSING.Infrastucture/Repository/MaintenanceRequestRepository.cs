using SSHOUSING.Domain.Entities;
using SSHOUSING.Domain.Interface;
using SSHOUSING.Infrastucture;
using System.Collections.Generic;

namespace SSHOUSING.Infrastructure.Repositories
{
    public class MaintenanceRequestRepository : IMaintenanceRequest
    {
        private readonly ApplicationDbContext _context;

        public MaintenanceRequestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<MaintenanceRequest> GetAll()
        {
            return _context.MaintenanceRequests.ToList();
        }

        public MaintenanceRequest GetById(int id)
        {
            return _context.MaintenanceRequests.Find(id);
        }

        public bool Add(MaintenanceRequest request)
        {
            _context.MaintenanceRequests.Add(request);
            return _context.SaveChanges() > 0;
        }

        public bool Update(MaintenanceRequest request)
        {
            _context.MaintenanceRequests.Update(request);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var request = _context.MaintenanceRequests.Find(id);
            if (request == null) return false;

            _context.MaintenanceRequests.Remove(request);
            return _context.SaveChanges() > 0;
        }
    }
}
