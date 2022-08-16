using Core.Models.Enuns;
using System;

namespace Core.Models
{
    public class Expense : Entity
    {
        public Expense()
        {
            Categoria = ECategory.Outras;
        }

        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public ECategory? Categoria { get; set; }
    }
}