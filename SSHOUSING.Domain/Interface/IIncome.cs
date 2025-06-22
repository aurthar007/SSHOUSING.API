// File: Domain/Interface/IIncome.cs
using SSHOUSING.Domain.Entities;
using System.Collections.Generic;

namespace SSHOUSING.Domain.Interface
{
    public interface IIncome
    {
        List<Income> GetAllIncome();
        Income GetIncomeById(int id);
        bool AddIncome(Income income);
        bool UpdateIncome(Income income);
        bool DeleteIncome(int id);
    }
}
