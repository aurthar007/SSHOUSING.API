using SSHOUSING.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHOUSING.Domain.Interface
{
    public interface ICountry
    {
        List<Country> GetAllCountry();
        Country GetCountryById(int Id);
        bool AddCountry(Country country);
        bool UpdateCountry(Country country);
        bool DeleteCountry(int Id);
    }
}
