using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.Api.Controllers
{
    public class IncomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
