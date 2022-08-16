using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services
{
    public class ExpenseServices : IExpenseServices
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseServices(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public Task<string> Create(Expense expense)
        {
            try
            {
                if (VerifyExpenseDescription(expense.Descricao, expense.Data))
                    return Task.FromResult("Receita já cadastrada");

                _expenseRepository.Insert(expense);

                var result = _expenseRepository.Get(expense.Id);

                return Task.FromResult(result.Id.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar receita", ex);
            }
        }

        public Task<IOrderedEnumerable<Expense>> GetList()
        {
            try
            {
                var result = _expenseRepository.List().OrderByDescending(x => x.Data);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<IOrderedEnumerable<Expense>> GetList(string filter)
        {
            try
            {
                var result = _expenseRepository.List(x => x.Descricao.Contains(filter)).OrderByDescending(x => x.Data);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public Task<IOrderedEnumerable<Expense>> GetList(DateTime dateTime)
        {
            try
            {
                var result = _expenseRepository.List(x => x.Data.Month == dateTime.Month && x.Data.Year == dateTime.Year).OrderByDescending(x => x.Data);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public Task<Expense> GetById(Guid id)
        {
            try
            {
                var result = _expenseRepository.Get(id);
                return Task.FromResult(result);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Task<string> Update(Expense expense)
        {
            try
            {
                if (VerifyExpenseDescription(expense.Descricao, expense.Data))
                    return Task.FromResult("Jà existe uma receita com essa descrição! Operação Cancelada");

                _expenseRepository.Update(expense);

                return Task.FromResult("ok");
            }
            catch (Exception ex)
            {
                return Task.FromResult($"Erro na atualização da receita: {ex.Message}");
            }

        }

        public Task<string> Delete(Guid id)
        {
            try
            {
                var expense = _expenseRepository.Get(id);
                if (expense == null)
                    return Task.FromResult("Receita não existe");

                _expenseRepository.Delete(expense);

                return Task.FromResult("Receita excluída com sucesso!");
            }
            catch (Exception)
            {
                return Task.FromResult("Erro na exclusão da receita!");
            }
        }

        #region Private Methods
        private bool VerifyExpenseDescription(string descricao, DateTime date)
        {
            var verifyExpense = _expenseRepository.List(x => x.Descricao == descricao && x.Data.Month == date.Month && x.Data.Year == date.Year);
            if (verifyExpense.Any())
                return true;

            return false;
        }
        #endregion
    }
}
