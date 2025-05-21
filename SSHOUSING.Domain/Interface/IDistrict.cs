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
        List<District> GetAllDistrict();
        District GetDistrictById(int Id);
        bool AddDistrict(District district);
        bool DeleteDistrict(int Id);
        bool UpdateDistrict(District district);
    }
}