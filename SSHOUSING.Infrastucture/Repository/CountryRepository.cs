using SSHOUSING.Domain.Entities;
using SSHOUSING.Domain.Interface;
using System;

namespace SSHOUSING.Infrastucture.Repository
{
   public class CountryRepository : ICountry
    {

        private readonly ApplicationDbContext _context;
        public CountryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool AddCountry(Country country)
        {
            _context.Countries.Add(country);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteCountry(int Id)
        {
            var d = _context.Countries.Find(Id);
            _context.Countries.Remove(d);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateCountry(Country country)
        {
            _context.Countries.Update(country);
            _context.SaveChanges();
            return true;
        }

        public List<Country> GetAllCountry()
        {
            return _context.Countries.ToList();
        }

        public Country GetCountryById(int Id)
        {
            return _context.Countries.Find(Id);
        }


    }
}
