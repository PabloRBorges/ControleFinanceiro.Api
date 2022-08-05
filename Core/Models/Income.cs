using System;

namespace Core.Models
{
    public class Income : Entity
    {
        public string Descricao { get; set; }
        public decimal? Valor { get; set; }
        public DateTime? Data { get; set; }
    }
}