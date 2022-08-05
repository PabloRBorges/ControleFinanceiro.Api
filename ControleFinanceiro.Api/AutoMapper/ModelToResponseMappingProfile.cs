using AutoMapper;
using ControleFinanceiro.Api.Models.Response;
using Core.Models;

namespace ControleFinanceiro.Api.AutoMapper
{
    public class ModelToResponseMappingProfile : Profile
    {
        public ModelToResponseMappingProfile()
        {
            CreateMap<Income, IncomeResponse>();
           // CreateMap<Expense, ExpenseResponse>();
        }
    }
}
