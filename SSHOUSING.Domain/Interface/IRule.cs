using SSHOUSING.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHOUSING.Domain.Interface
{
    public interface IRule
    {
        Task<IEnumerable<Rule>> GetAllAsync();
        Task<Rule> AddAsync(Rule rule);
    }
}
