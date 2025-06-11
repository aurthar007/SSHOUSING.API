using Microsoft.EntityFrameworkCore;
using SSHOUSING.Domain.Entities;
using SSHOUSING.Domain.Interface;
using SSHOUSING.Infrastucture;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class BillingRepository : IBilling
{
    private readonly ApplicationDbContext _context;

    public BillingRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<IEnumerable<Billing>> GetAllAsync()
    {
        var data = _context.Billings.AsEnumerable();
        return Task.FromResult(data);
    }

    public Task<Billing> GetByIdAsync(int id)
    {
        var billing = _context.Billings.FirstOrDefault(b => b.Id == id);
        return Task.FromResult(billing);
    }

    public Task<Billing> AddAsync(Billing billing)
    {
        _context.Billings.Add(billing);
        _context.SaveChanges();
        return Task.FromResult(billing);
    }

    public Task<Billing> UpdateAsync(Billing billing)
    {
        _context.Billings.Update(billing);
        _context.SaveChanges();
        return Task.FromResult(billing);
    }

    public Task<bool> DeleteAsync(int id)
    {
        var billing = _context.Billings.FirstOrDefault(b => b.Id == id);
        if (billing == null) return Task.FromResult(false);

        _context.Billings.Remove(billing);
        _context.SaveChanges();
        return Task.FromResult(true);
    }
}
