using SSHOUSING.Domain.Entities;
using SSHOUSING.Domain.Interface;
using SSHOUSING.Infrastucture;
using System.Collections.Generic;
using System.Linq;

namespace SSHOUSING.Infrastructure.Repository
{
    public class PropertyRepository : IProperty
    {
        private readonly ApplicationDbContext _context;

        public PropertyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Property> GetAllProperty()
        {
            return _context.Properties.ToList(); // Synchronous method
        }

        public bool AddProperty(Property property)
        {
            _context.Properties.Add(property); // Synchronous add
            return _context.SaveChanges() > 0; // Save and return true if at least one row was affected
        }
    }
}
