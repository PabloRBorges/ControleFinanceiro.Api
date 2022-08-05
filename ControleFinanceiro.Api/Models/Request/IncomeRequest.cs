using System;

namespace ControleFinanceiro.Api.Models.Request
{
    public class IncomeRequest
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
    }
}
