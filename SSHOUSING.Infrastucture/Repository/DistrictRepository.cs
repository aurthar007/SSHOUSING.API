using SSHOUSING.Domain.Entities;
using SSHOUSING.Domain.Interface;

namespace SSHOUSING.Infrastucture.Repository
{
    public class DistrictRepository : IDistrict
    {
        private readonly ApplicationDbContext _context;
        public DistrictRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool AddDistrict(District district)
        {
            _context.Districts.Add(district);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteDistrict(int Id)
        {
            var d = _context.Districts.Find(Id);
            _context.Districts.Remove(d);
            _context.SaveChanges();
            return true;
        }

        public List<District> GetAllDistrict()
        {
            return _context.Districts.ToList();
        }

        public District GetDistrictById(int Id)
        {
            return _context.Districts.Find(Id);
        }

        public bool UpdateDistrict(District district)
        {
            _context.Districts.Update(district);
            _context.SaveChanges();
            return true;
        }
    }
}