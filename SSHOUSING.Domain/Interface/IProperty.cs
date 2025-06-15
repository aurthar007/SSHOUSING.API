using SSHOUSING.Domain.Entities;
using System.Collections.Generic;

namespace SSHOUSING.Domain.Interface
{
    public interface IProperty
    {
        List<Property> GetAllProperty();
        Property GetPropertyById(int id);
        bool AddProperty(Property property);
        bool DeleteProperty(int id);
        bool UpdateProperty(Property property);
    }
}
