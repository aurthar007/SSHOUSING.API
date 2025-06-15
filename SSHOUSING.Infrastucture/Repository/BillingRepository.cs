using System;
using System.Collections.Generic;
using System.Linq;
using SSHOUSING.Domain.Entities;
using SSHOUSING.Domain.Interface;

namespace SSHOUSING.Infrastucture.Repository
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
            if (billing == null) return false;

            _context.Billings.Add(billing);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateBilling(Billing billing)
        {
            var existing = _context.Billings.FirstOrDefault(b => b.Id == billing.Id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(billing);
            return _context.SaveChanges() > 0;
        }

        public bool DeleteBilling(int id)
        {
            var billing = _context.Billings.FirstOrDefault(b => b.Id == id);
            if (billing == null) return false;

            _context.Billings.Remove(billing);
            return _context.SaveChanges() > 0;
        }

        // Fixed: Correct return type as per IBilling
        public List<(string Month, decimal TotalRevenue)> GetMonthlyRevenueStats()
        {
            return _context.Billings
                .GroupBy(b => b.Date.ToString("yyyy-MM"))
                .ToList() // Materialize first to avoid expression tree errors
                .Select(g => (Month: g.Key, TotalRevenue: g.Sum(b => b.Amount)))
                .ToList();
        }
    }
}
