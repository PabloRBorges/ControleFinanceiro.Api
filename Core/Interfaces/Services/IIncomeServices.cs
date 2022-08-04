using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public  interface IIncomeServices
    {
        Task CreateIncome(string description, DateTime dateTime, double valor);
    }
}
