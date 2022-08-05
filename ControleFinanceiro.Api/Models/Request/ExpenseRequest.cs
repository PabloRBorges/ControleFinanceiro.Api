using System;

namespace ControleFinanceiro.Api.Models.Request
{
    public class ExpenseRequest
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
    }
}
