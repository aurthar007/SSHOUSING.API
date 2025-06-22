using SSHOUSING.Domain.Entities;
using SSHOUSING.Domain.Interface;
using SSHOUSING.Infrastucture;
using System.Collections.Generic;
using System.Linq;

namespace SSHOUSING.Infrastructure.Repository
{
    public class IncomeRepository : IIncome
    {
        private readonly ApplicationDbContext _context;

        public IncomeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

     
        public List<Income> GetAllIncome()
        {
            return _context.Incomes.ToList();
        }


        public Income GetIncomeById(int id)
        {
            return _context.Incomes.FirstOrDefault(i => i.Id == id);
        }

        public bool AddIncome(Income income)
        {
            _context.Incomes.Add(income);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateIncome(Income income)
        {
            var existing = _context.Incomes.Find(income.Id);
            if (existing == null) return false;

            existing.Month = income.Month;
            existing.Rent = income.Rent;
            existing.Maintenance = income.Maintenance;

            _context.Incomes.Update(existing);
            return _context.SaveChanges() > 0;
        }

 
        public bool DeleteIncome(int id)
        {
            var income = _context.Incomes.Find(id);
            if (income == null) return false;

            _context.Incomes.Remove(income);
            return _context.SaveChanges() > 0;
        }
    }
}
