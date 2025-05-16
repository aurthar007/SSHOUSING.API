using SSHOUSING.Domain.Entities;
using SSHOUSING.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHOUSING.Infrastucture.Repository
{

    public class CountryRepository : ICountry
    {
        private readonly ApplicationDbContext _context;

        public CountryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Country country)
        {
            _context.Countries.Add(country);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var country = _context.Countries.Find(id);
            _context.Countries.Remove(country);
            _context.SaveChanges();
            return true;
        }

        public List<Country> GetAll()
        {
            return _context.Countries.ToList();
        }

        public Country GetById(int id)
        {
            return _context.Countries.Find(id);
        }

        public bool Update(Country country)
        {
            _context.Countries.Update(country);
            _context.SaveChanges();
            return true;
        }
    }
}
