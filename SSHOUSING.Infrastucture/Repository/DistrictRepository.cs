using SSHOUSING.Domain.Entities;
using SSHOUSING.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHOUSING.Infrastucture.Repository
{
    public class DistrictRepository : IDistrict
    {
        private readonly ApplicationDbContext _context;

        public DistrictRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(District district)
        {
            _context.Districts.Add(district);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var district = _context.Districts.Find(id);
            if (district == null) return false;

            _context.Districts.Remove(district);
            _context.SaveChanges();
            return true;
        }

        public List<District> GetAll()
        {
            return _context.Districts.ToList();
        }

        public District GetById(int id)
        {
            return _context.Districts.Find(id);
        }

        public bool Update(District district)
        {
           _context.Districts.Update(district);
            _context.SaveChanges();
            return true;
        }
    }
}