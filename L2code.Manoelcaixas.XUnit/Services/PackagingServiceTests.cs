using L2code.Manoelcaixas.Application.DTOs.OutputBoxes;
using L2code.Manoelcaixas.Application.DTOs;
using Xunit;
using System.Text.Json;
using L2code.Manoelcaixas.Application.Services;

namespace L2code.Manoelcaixas.XUnit.Services
{

    public class PackagingServiceTests
    {
        private readonly PackagingService _service;

        public PackagingServiceTests()
        {
            _service = new PackagingService();
        }

        [Fact]
        public async Task PackagingProducts_ShouldReturnWithoutBox()
        {
            var orderWithProductWithoutPackaging = JsonSerializer.Deserialize<InputOrdersDTO>(TestData.OrdersData.orderWithProductWithoutPackaging);

            var packagingFeedbackDTO = _service.PackagingProducts(orderWithProductWithoutPackaging);

            Assert.Equal("Produto não cabe em nenhuma caixa disponível.", packagingFeedbackDTO.Orders[0].Boxes[0].Note);

        }

        [Fact]
        public async Task PackagingProducts_ShouldReturnExpectedResult()
        {
            var orderWithProductWithoutPackaging = JsonSerializer.Deserialize<InputOrdersDTO>(TestData.OrdersData.orderWithProductWithoutPackaging);

            var result = JsonSerializer.Deserialize<PackagingFeedbackDTO>(TestData.OrdersData.result);

            var packagingFeedbackDTO = _service.PackagingProducts(orderWithProductWithoutPackaging);

            Assert.Equal(result, packagingFeedbackDTO);

        }
    }

}
