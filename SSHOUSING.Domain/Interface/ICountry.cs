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
        List<Country> GetAll();
        Country GetById(int id);
        bool Add(Country country);
        bool Update(Country country);
        bool Delete(int id);
    }
}
