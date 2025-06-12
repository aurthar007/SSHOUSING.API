using Microsoft.EntityFrameworkCore;
using SSHOUSING.Domain.Entities;
using SSHOUSING.Domain.Interface;
using SSHOUSING.Infrastucture;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SSHOUSING.Infrastructure.Repositories
{
    public class RuleRepository : IRule
    {
        private readonly ApplicationDbContext _context;

        public RuleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Rule>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Rule>>(_context.Rules.ToList());
        }

        public Task<Rule> AddAsync(Rule rule)
        {
            _context.Rules.Add(rule);
            _context.SaveChanges();
            return Task.FromResult(rule);
        }
    }
}
