using Core.Models.Enuns;
using System;

namespace Core.Models
{
    public class Income : Entity
    {
        public Income()
        {
            Categoria = ECategory.Outras;
        }

        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public ECategory? Categoria { get; set; }

        
    }
}