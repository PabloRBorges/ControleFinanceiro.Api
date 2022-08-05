using System;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IIncomeServices
    {
        Task<string> CreateIncome(string description, DateTime dateTime, decimal valor);
    }
}
