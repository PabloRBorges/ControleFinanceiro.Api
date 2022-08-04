using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
using System;
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

        public async Task CreateIncome(string description, DateTime dateTime, double valor)
        {
            var income = new Income()
            {
                Data = dateTime,
                Descricao = description,
                Valor = valor
            };

            await _incomeRepository.Save(income);
        }
    }
}
