using Core.Interfaces.Services;
using Core.Models;
using Core.Models.Enuns;
using NSubstitute;
using System;
using System.Threading.Tasks;
using Xunit;

namespace TestProject
{
    public class IncomeControllerTests
    {

        private readonly IIncomeServices _expenseServices;
        private readonly DateTime _startDate = DateTime.Now;

        public IncomeControllerTests()
        {

            //Create:
            _expenseServices = Substitute.For<IIncomeServices>();
            _expenseServices.Create(new Income() { Valor = 10, Categoria = ECategory.Alimentacao, Data = _startDate, Descricao = "Teste de envio" }).Returns("Teste");
            _expenseServices.GetById(Guid.Parse("3292EA4A-BE44-4E48-8919-4A9B4AC1D0B8")).Returns(new Income()
            {
                Id = Guid.Parse("3292EA4A-BE44-4E48-8919-4A9B4AC1D0B8"),
                Valor = 10,
                Categoria = ECategory.Alimentacao,
                Data = _startDate,
                Descricao = "Teste de envio"
            });
        }

        [Fact]
        public async Task Json_ReturnsAViewResult_WithAListOfGetById()
        {
            //act
            var getId = Guid.Parse("3292EA4A-BE44-4E48-8919-4A9B4AC1D0B8");
            var result = new Income()
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
