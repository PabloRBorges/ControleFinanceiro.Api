using System;

namespace Core.Models
{
    public class Expense : Entity
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
    }
}