using AutoMapper;
using ControleFinanceiro.Api.Models.Request;
using Core.Models;

namespace ControleFinanceiro.Api.AutoMapper
{

    public class RequestToModelMappingProfile : Profile
    {
        public RequestToModelMappingProfile()
        {
            CreateMap<IncomeRequest, Income>();
            CreateMap<ExpenseRequest, Expense>();
        }
    }
}
