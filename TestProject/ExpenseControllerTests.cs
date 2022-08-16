using ControleFinanceiro.Api.Controllers;
using Core.Interfaces.Services;
using Core.Models;
using Core.Models.Enuns;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TestProject
{
    public class ExpenseControllerTests
    {

        private readonly IExpenseServices _expenseServices;
        private readonly DateTime _startDate = DateTime.Now;

        public ExpenseControllerTests()
        {

            //Create:
            _expenseServices = Substitute.For<IExpenseServices>();
            _expenseServices.Create(new Expense() { Valor = 10, Categoria = ECategory.Alimentacao, Data = _startDate, Descricao = "Teste de envio" }).Returns("Teste");
            _expenseServices.GetById(Guid.Parse("3292EA4A-BE44-4E48-8919-4A9B4AC1D0B8")).Returns(new Expense() 
            {
                Id= Guid.Parse("3292EA4A-BE44-4E48-8919-4A9B4AC1D0B8"),  
                Valor = 10, 
                Categoria = ECategory.Alimentacao, 
                Data = _startDate, 
                Descricao = "Teste de envio" });
            }

        [Fact]
        public async Task Json_ReturnsAViewResult_WithAListOfGetById()
        {
            //act
            var getId = Guid.Parse("3292EA4A-BE44-4E48-8919-4A9B4AC1D0B8");
            var result = new Expense() 
            { 
                Valor = 10, 
                Categoria = ECategory.Alimentacao, 
                Data = _startDate, 
                Descricao = "Teste de envio", 
                Id = getId 
            };

            //arrange
            var value = await _expenseServices.GetById(getId);

            //assert
            Assert.Equal(value.Valor, result.Valor);
        }

        [Fact]
        public async Task Invalid_IdAViewResult_WithAListOfGetById()
        {
            //act
            var invalidId = new Guid();

            //arrange
            var value = await _expenseServices.GetById(invalidId);

            //assert
            Assert.Null(value);
        }
    }
}
