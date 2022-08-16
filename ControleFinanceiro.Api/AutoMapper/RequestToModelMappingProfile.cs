using AutoMapper;
using ControleFinanceiro.Api.Models.Request;
using Core.Models;
using Core.Models.Enuns;

namespace ControleFinanceiro.Api.AutoMapper
{

    public class RequestToModelMappingProfile : Profile
    {
        public RequestToModelMappingProfile()
        {
            CreateMap<IncomeRequest, Income>()
                .ForMember(dst => dst.Categoria, map => map.MapFrom(src => src.Categoria == null ? ECategory.Outras : src.Categoria));
            CreateMap<ExpenseRequest, Expense>()
                .ForMember(dst => dst.Categoria, map => map.MapFrom(src => src.Categoria == null ? ECategory.Outras : src.Categoria));
        }
    }
}
