using AutoMapper;
using ControleFinanceiro.Api.Models.Response;
using Core.Models;
using Core.Models.Enuns;
using EnumsNET;

namespace ControleFinanceiro.Api.AutoMapper
{
    public class ModelToResponseMappingProfile : Profile
    {
        public ModelToResponseMappingProfile()
        {
            CreateMap<Income, IncomeResponse>()
                .ForMember(dst => dst.Categoria, map => map.MapFrom(src => src.Categoria.HasValue ? (src.Categoria).Value.AsString(EnumFormat.Description) : "Outras"));

            CreateMap<Expense, ExpenseResponse>()
                .ForMember(dst => dst.Categoria, map => map.MapFrom(src => src.Categoria.HasValue ? (src.Categoria).Value.AsString(EnumFormat.Description) : "Outras"));
        }
    }
}
