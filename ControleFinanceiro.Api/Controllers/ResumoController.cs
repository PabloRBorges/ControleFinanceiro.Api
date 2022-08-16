using Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ControleFinanceiro.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("resumo")]
    public class ResumoController : Controller
    {
        private readonly IResumeServices _resumeServices;

        public ResumoController(IResumeServices resumeServices)
        {
            _resumeServices = resumeServices;
        }

        [HttpGet]
        [Route("{ano}/{mes}")]
        public async Task<IActionResult> Get(int ano, int mes)
        {
            var dateTime = new DateTime(ano, mes, 1);

            var resut = await _resumeServices.AmountByMonth(dateTime);

            return Ok(resut);
        }
    }
}
