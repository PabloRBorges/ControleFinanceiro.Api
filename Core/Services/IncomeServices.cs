using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services
{
    public class IncomeServices : IIncomeServices
    {
        private readonly IIncomeRepository _incomeRepository;

        public IncomeServices(IIncomeRepository incomeRepository)
        {
            _incomeRepository = incomeRepository;
        }

        public Task<string> Create(Income income)
        {
            try
            {
                if (VerifyIncomeDescription(income.Descricao, income.Data))
                    return Task.FromResult("Receita já cadastrada");

                _incomeRepository.Insert(income);

                var result = _incomeRepository.Get(income.Id);

                return Task.FromResult(result.Id.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar receita", ex);
            }
        }

        public Task<IOrderedEnumerable<Income>> GetList()
        {
            try
            {
                var result = _incomeRepository.List().OrderByDescending(x => x.Data);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<Income> GetById(Guid id)
        {
            try
            {
                var result = _incomeRepository.Get(id);
                return Task.FromResult(result);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Task<string> Update(Income income)
        {
            try
            {
                if (VerifyIncomeDescription(income.Descricao, income.Data))
                    return Task.FromResult("Jà existe uma receita com essa descrição! Operação Cancelada");

                _incomeRepository.Update(income);

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
                var income = _incomeRepository.Get(id);
                if (income == null)
                    return Task.FromResult("Receita não existe");

                _incomeRepository.Delete(income);

                return Task.FromResult("Receita excluída com sucesso!");
            }
            catch (Exception)
            {
                return Task.FromResult("Erro na exclusão da receita!");
            }
        }

        #region Private Methods
        private bool VerifyIncomeDescription(string descricao, DateTime date)
        {
            var verifyIncome = _incomeRepository.List(x => x.Descricao == descricao && x.Data.Month == date.Month && x.Data.Year == date.Year);
            if (verifyIncome.Any())
                return true;

            return false;
        }
        #endregion
    }
}
