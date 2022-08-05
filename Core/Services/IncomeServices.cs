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

        public async Task<string> CreateIncome(string description, DateTime dateTime, decimal valor)
        {
            var income = new Income()
            {
                Id = Guid.NewGuid(),
                Data = dateTime,
                Descricao = description,
                Valor = valor
            };

            _incomeRepository.Insert(income);
            return "ok";
        }
    }
}
