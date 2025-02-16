﻿using System;

namespace ControleFinanceiro.Api.Models.Response
{
    public class IncomeResponse
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public decimal? Valor { get; set; }
        public DateTime? Data { get; set; }
        public string Categoria { get; set; }
    }
}
