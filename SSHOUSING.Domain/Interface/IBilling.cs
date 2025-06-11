using System.Collections.Generic;
using System.Threading.Tasks;
using SSHOUSING.Domain.Entities;

public interface IBilling
{
    Task<IEnumerable<Billing>> GetAllAsync();
    Task<Billing> GetByIdAsync(int id);
    Task<Billing> AddAsync(Billing billing);
    Task<Billing> UpdateAsync(Billing billing);
    Task<bool> DeleteAsync(int id);
}
