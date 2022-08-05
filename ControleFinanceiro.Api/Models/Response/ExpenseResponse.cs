using System;

namespace ControleFinanceiro.Api.Models.Response
{
    public class ExpenseResponse
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public decimal? Valor { get; set; }
        public DateTime? Data { get; set; }
    }
}
