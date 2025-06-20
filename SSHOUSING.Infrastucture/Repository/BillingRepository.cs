using Microsoft.EntityFrameworkCore;
using SSHOUSING.Domain.Entities;
using SSHOUSING.Domain.Interface;
using SSHOUSING.Infrastucture;
using System.Collections.Generic;
using System.Linq;

namespace SSHOUSING.Infrastructure.Repository
{
    public class BillingRepository : IBilling
    {
        private readonly ApplicationDbContext _context;

        public BillingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Billing> GetAllBilling()
        {
            return _context.Billings.ToList();
        }

        public Billing GetBillingById(int id)
        {
            return _context.Billings.FirstOrDefault(b => b.Id == id);
        }

        public bool AddBilling(Billing billing)
        {
            _context.Billings.Add(billing);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateBilling(Billing billing)
        {
            _context.Billings.Update(billing);
            return _context.SaveChanges() > 0;
        }

        public bool DeleteBilling(int id)
        {
            var billing = _context.Billings.FirstOrDefault(b => b.Id == id);
            if (billing == null) return false;

            _context.Billings.Remove(billing);
            return _context.SaveChanges() > 0;
        }
    }
}
