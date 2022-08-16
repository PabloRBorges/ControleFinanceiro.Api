using Core.Models.Enuns;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Core.Models
{
    public class Resume
    {
        public decimal TotalReceitasMes { get; set; }
        public decimal TotalDespesasMes { get; set; }
        public decimal TotalDoMes { get; set; }
        public List<ResumoCategoria> GastoMesPorCategoria { get; set; }
    }
}
