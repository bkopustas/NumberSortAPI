using NumberSortAPI.Services;
using Xunit;

namespace NumberSortAPITests
{
    public class SortingSpeedComparisonServiceTests
    {
        [Fact]
        public void ShouldReturnRunTime()
        {
            // Arrange
            var sortingService = new SortingSpeedComparisonService();
            var numbers = new List<int> { 3, 2, 1 }; 
            var sortingAlgorithm = new Action<List<int>>(list => list.Sort()); 

            // Act
            var elapsedTime = sortingService.MeasureSort(numbers, sortingAlgorithm);

            // Assert
            Assert.True(elapsedTime.TotalMilliseconds >= 0); 
        }
    }
}
