using SSHOUSING.Domain.Entities;
using System.Collections.Generic;

namespace SSHOUSING.Domain.Interface
{
    public interface IProperty
    {
        List<Property> GetAllProperty();
            bool AddProperty(Property property);
       
    }
}
