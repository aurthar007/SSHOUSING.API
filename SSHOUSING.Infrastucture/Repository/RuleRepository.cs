using SSHOUSING.Domain.Entities;
using SSHOUSING.Domain.Interface;
using SSHOUSING.Infrastucture;
using System.Collections.Generic;
using System.Linq;

namespace SSHOUSING.Infrastructure.Repositories
{
    public class RuleRepository : IRule
    {
        private readonly ApplicationDbContext _context;

        public RuleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Rule> GetAllRules()
        {
            return _context.Rules.ToList();
        }

        public bool AddRule(Rule rule)
        {
            _context.Rules.Add(rule);
            return _context.SaveChanges() > 0;
        }

           }
}
