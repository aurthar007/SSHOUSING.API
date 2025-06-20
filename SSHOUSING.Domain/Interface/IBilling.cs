using SSHOUSING.Domain.Entities;
using System.Collections.Generic;

namespace SSHOUSING.Domain.Interface
{
    public interface IBilling
    {
        List<Billing> GetAllBilling();
        Billing GetBillingById(int id);
        bool AddBilling(Billing billing);
        bool UpdateBilling(Billing billing);
        bool DeleteBilling(int id);
    }
}
