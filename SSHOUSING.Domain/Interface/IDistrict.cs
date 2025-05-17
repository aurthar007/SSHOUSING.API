using SSHOUSING.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHOUSING.Domain.Interface
{
    public interface IDistrict
    {
        List<District> GetAll();
        District GetById(int id);
        bool Add(District district);
        bool Update(District district);
        bool Delete(int id);
    }
}
