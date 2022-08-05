using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ControleFinanceiro.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IncomeController : ControllerBase
    {
        private readonly IIncomeServices _incomeServices;

        public IncomeController(IIncomeServices incomeServices)
        {
            _incomeServices = incomeServices;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result =  _incomeServices.CreateIncome("compra do mês", DateTime.Now, 29);

            return Ok("Ok");
        }
    }
}
