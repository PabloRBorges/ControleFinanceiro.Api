using AutoMapper;
using ControleFinanceiro.Api.Models.Request;
using ControleFinanceiro.Api.Models.Response;
using Core.Interfaces.Services;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleFinanceiro.Api.Controllers
{
    [ApiController]
    [Route("despesas")]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseServices _expenseServices;
        private readonly IMapper _mapper;

        public ExpenseController(IExpenseServices expenseServices, IMapper mapper)
        {
            _expenseServices = expenseServices;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = _mapper.Map<IList<ExpenseResponse>>(await _expenseServices.GetList());

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = _mapper.Map<ExpenseResponse>(await _expenseServices.GetById(id));

            if (result == null)
                return Ok("Id not found");

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ExpenseRequest expenseRequest)
        {
            var expense = _mapper.Map<Expense>(expenseRequest);

            var result = await _expenseServices.Create(expense);

            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put([FromBody] ExpenseRequest expenseRequest, Guid id)
        {
            var expense = _mapper.Map<Expense>(expenseRequest);

            expense.Id = id;

            var result = await _expenseServices.Update(expense);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _expenseServices.Delete(id);
            return Ok(result);
        }
    }
}
