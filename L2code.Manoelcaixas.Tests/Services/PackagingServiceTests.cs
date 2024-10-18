using L2code.Manoelcaixas.Application.DTOs;
using L2code.Manoelcaixas.Application.DTOs.OutputBoxes;
using L2code.Manoelcaixas.Application.Services;
using System.Text.Json;

namespace L2code.Manoelcaixas.Tests
{
    public class PackagingServiceTests
    {
        private readonly PackagingService _service;

        public PackagingServiceTests()
        {
            _service = new PackagingService();
        }

        [Fact]
        public void PackagingProducts_ShouldReturnWithoutBox()
        {
            var orderWithProductWithoutPackaging = JsonSerializer.Deserialize<InputOrdersDTO>(TestData.OrdersData.orderWithProductWithoutPackaging);

            var packagingFeedbackDTO = _service.PackagingProducts(orderWithProductWithoutPackaging);

            var messageForOrder = packagingFeedbackDTO.Orders[0].Boxes[0].Note;

            Assert.Equal(TestData.OrdersData.productWithOutBoxMessage, messageForOrder);
        }

        [Fact]
        public void PackagingProducts_ShouldReturnWithPacking()
        {
            var orderWithProductWithPackaging = JsonSerializer.Deserialize<InputOrdersDTO>(TestData.OrdersData.orderWithProductWithPackaging);

            var packagingFeedbackDTO = _service.PackagingProducts(orderWithProductWithPackaging);

            foreach(var item in packagingFeedbackDTO.Orders[0].Boxes)
            {
                Assert.NotEqual(TestData.OrdersData.productWithOutBoxMessage, item.Note);

            }
            
        }

        [Fact]
        public void PackagingProducts_ShouldReturnManyBoxProduct()
        {
            var orderWithManyBoxProduct = JsonSerializer.Deserialize<InputOrdersDTO>(TestData.OrdersData.orderWithManyBoxProduct);

            var packagingFeedbackDTO = _service.PackagingProducts(orderWithManyBoxProduct);

            Assert.NotEqual((int)default, packagingFeedbackDTO.Orders[0].Boxes.Count());
            
        }


    }
}