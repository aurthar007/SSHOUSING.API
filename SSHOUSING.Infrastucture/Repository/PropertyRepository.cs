using SSHOUSING.Application.Interfaces; // Correct interface
using SSHOUSING.Domain.Entities;
using SSHOUSING.Infrastructure; // FIXED spelling from Infrastucture to Infrastructure
using SSHOUSING.Infrastucture;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSHOUSING.Infrastructure.Repository // FIXED namespace
{
    public class PropertyRepository : IProperty // FIXED interface name
    {
        private readonly ApplicationDbContext _context;

        public PropertyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Property>> GetAllAsync()
        {
            var properties = _context.Properties.ToList(); // Sync
            return Task.FromResult(properties.AsEnumerable());
        }

        public Task<Property> AddAsync(Property property)
        {
            _context.Properties.Add(property); // Sync
            _context.SaveChanges();            // Sync
            return Task.FromResult(property);
        }
    }
}
