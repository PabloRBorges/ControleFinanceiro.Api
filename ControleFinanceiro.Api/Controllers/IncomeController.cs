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
    [Route("receitas")]
    public class IncomeController : ControllerBase
    {
        private readonly IIncomeServices _incomeServices;
        private readonly IMapper _mapper;

        public IncomeController(IIncomeServices incomeServices, IMapper mapper)
        {
            _incomeServices = incomeServices;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = _mapper.Map<IList<IncomeResponse>>(await _incomeServices.GetList());

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = _mapper.Map<IncomeResponse>(await _incomeServices.GetById(id));

            if (result == null)
                return Ok("Id not found");

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] IncomeRequest incomeRequest)
        {
            var income = _mapper.Map<Income>(incomeRequest);

            var result = await _incomeServices.Create(income);

            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put([FromBody] IncomeRequest incomeRequest, Guid id)
        {
            var income = _mapper.Map<Income>(incomeRequest);

            income.Id = id;

            var result = await _incomeServices.Update(income);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _incomeServices.Delete(id);
            return Ok(result);
        }
    }
}
