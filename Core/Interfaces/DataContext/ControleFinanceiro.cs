using Microsoft.EntityFrameworkCore;
using System;

namespace Core.Interfaces.DataContext
{
    public class ControleFinanceiro : DbContext, IControleFinanceiro
    {
        protected ControleFinanceiro(string connection) : base(connection)
        {
        }
    }
}
