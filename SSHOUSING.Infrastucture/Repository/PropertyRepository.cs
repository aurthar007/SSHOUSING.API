using SSHOUSING.Domain.Entities;
using SSHOUSING.Domain.Interface;
using SSHOUSING.Infrastructure; // ✅ FIXED namespace spelling
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
            return _context.Properties.ToList();
        }

        public Property GetPropertyById(int id)
        {
            return _context.Properties.FirstOrDefault(p => p.Id == id);
        }

        public bool AddProperty(Property property)
        {
            _context.Properties.Add(property);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateProperty(Property property)
        {
            var existing = _context.Properties.FirstOrDefault(p => p.Id == property.Id);
            if (existing == null) return false;

            // ✅ Update fields
            existing.Name = property.Name;
            existing.Location = property.Location;
            existing.Units = property.Units;
            existing.OccupiedUnits = property.OccupiedUnits;

            _context.Properties.Update(existing); // Optional: for clarity
            return _context.SaveChanges() > 0;
        }

        public bool DeleteProperty(int id)
        {
            var property = _context.Properties.FirstOrDefault(p => p.Id == id);
            if (property == null) return false;

            _context.Properties.Remove(property);
            return _context.SaveChanges() > 0;
        }
    }
}
