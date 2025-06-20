using SSHOUSING.Domain.Entities;
using System.Collections.Generic;

namespace SSHOUSING.Domain.Interface
{
    public interface IRule
    {
        List<Rule> GetAllRules();

        bool AddRule(Rule rule);
     
    }
}
