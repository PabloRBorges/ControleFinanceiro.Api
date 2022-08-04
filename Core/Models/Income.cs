using System;

namespace Core.Models
{
    public class Income : Entity
    {
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public DateTime Data { get; set; }
    }
}