using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
using Core.Models.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class ResumeServices : IResumeServices
    {
        private readonly IIncomeRepository _incomeRepository;
        private readonly IExpenseRepository _expenseRepository;

        public ResumeServices(IIncomeRepository incomeRepository, IExpenseRepository expenseRepository)
        {
            _incomeRepository = incomeRepository;
            _expenseRepository = expenseRepository;
        }

        public Task<Resume> AmountByMonth(DateTime datetime)
        {
            var result = new Resume();

            var amountExpense = _expenseRepository.List(x => x.Data.Month == datetime.Month && x.Data.Year == datetime.Year).Sum(z => z.Valor);
            var amountIncome = _incomeRepository.List(x => x.Data.Month == datetime.Month && x.Data.Year == datetime.Year).Sum(z => z.Valor);
            var amount = amountIncome - amountExpense;

            var listCategory = _expenseRepository.List(x => x.Data.Month == datetime.Month && x.Data.Year == datetime.Year)
                .GroupBy(x => x.Categoria.HasValue ? x.Categoria : ECategory.Outras )
                .Select(group => new ResumoCategoria 
                    { 
                        Total = group.Sum( x=> x.Valor), 
                        Categoria = group.Key.Value.ToString()  
                    }
                ).ToList();

            result.GastoMesPorCategoria = listCategory;
            result.TotalDoMes = amount;
            result.TotalDespesasMes = amountExpense;
            result.TotalReceitasMes = amountIncome;

            return Task.FromResult(result);
        }
    }
}
