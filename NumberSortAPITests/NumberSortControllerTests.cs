using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using NumberSortAPI.Controllers;
using NumberSortAPI.Services;
using NumberSortAPI.Models;
using Xunit;
using NumberSortAPI.SortingAlgorithms;

namespace NumberSortAPITests
{
    public class NumberSortControllerTests
    {
        [Fact]
        public void ShouldReturnBadRequestWhenRequestIsNull()
        {
            var numberSortServiceMock = new Mock<NumberSortService>();
            var controller = new NumberSortController(numberSortServiceMock.Object);

            var result = controller.SortNumbers(null);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void ShouldReturnBadRequestWhenNumbersAreNull()
        {
            var numberSortServiceMock = new Mock<NumberSortService>();
            var controller = new NumberSortController(numberSortServiceMock.Object);
            var request = new NumberSortRequest { Numbers = null };

            var result = controller.SortNumbers(request);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void ShouldReturnOkResultWhenSortOk()
        {
            var numberSortService = new NumberSortService(new FileService(), new BubbleSort());
            var controller = new NumberSortController(numberSortService);
            var request = new NumberSortRequest { Numbers = new List<int> { 3, 2, 1 } };

            var result = controller.SortNumbers(request);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var sortedNumbers = Assert.IsType<List<int>>(okResult.Value);
            Assert.Equal(new List<int> { 1, 2, 3 }, sortedNumbers);
        }

    }
}
