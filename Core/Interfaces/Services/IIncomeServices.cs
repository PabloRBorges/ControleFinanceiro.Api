using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IIncomeServices
    {
        Task<string> Create(Income income);
        Task<IOrderedEnumerable<Income>> GetList();
        Task<Income> GetById(Guid id);
        Task<string> Update(Income income);
        Task<string> Delete(Guid id);
    }
}
