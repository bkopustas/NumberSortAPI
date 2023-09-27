using Microsoft.AspNetCore.Mvc;
using Moq;
using NumberSortAPI.Controllers;
using NumberSortAPI.Services;
using NumberSortAPI.Models;
using Xunit;

namespace NumberSortAPITests
{
    public class SortingSpeedComparisonControllerTests
    {
        [Fact]
        public void ShouldReturnBadRequestWithInvalidInput()
        {
            var sortingServiceMock = new Mock<SortingSpeedComparisonService>();
            var controller = new SortingSpeedComparisonController(sortingServiceMock.Object);
            var numbers = new List<int>();

            var result = controller.BenchmarkSortingAlgorithms(numbers);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Invalid input.", badRequestResult.Value);
        }
    }
}
