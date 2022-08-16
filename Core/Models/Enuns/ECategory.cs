using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Enuns
{
    public enum ECategory
    {
        [Description("Alimentação")]
        Alimentacao,
        [Description("Saúde")]
        Saúde,
        [Description("Moradia")]
        Moradia,
        [Description("Transporte")]
        Transporte,
        [Description("Educação")]
        Educacao,
        [Description("Lazer")]
        Lazer,
        [Description("Imprevistos")]
        Imprevistos,
        [Description("Outras")]
        Outras
    }
}
