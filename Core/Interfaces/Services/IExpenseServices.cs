using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IExpenseServices
    {
        Task<string> Create(Expense income);
        Task<IOrderedEnumerable<Expense>> GetList();
        Task<Expense> GetById(Guid id);
        Task<string> Update(Expense income);
        Task<string> Delete(Guid id);
    }
}
