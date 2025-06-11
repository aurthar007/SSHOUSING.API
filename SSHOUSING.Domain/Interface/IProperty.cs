using SSHOUSING.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHOUSING.Application.Interfaces
{
    public interface IProperty
    {
        Task<IEnumerable<Property>> GetAllAsync();
        Task<Property> AddAsync(Property property);
    }
}
