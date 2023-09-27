using Xunit;
using Moq;
using NumberSortAPI.Services;
using NumberSortAPI.Interfaces;

namespace NumberSortAPITests
{
    public class NumberSortServiceTests
    {
        [Fact]
        public void ShouldSortNumbersCorrectly()
        {
            
            var sortAlgorithmMock = new Mock<ISortAlgorithm>();
            sortAlgorithmMock.Setup(sa => sa.Sort(It.IsAny<List<int>>()))
            .Callback<List<int>>(list => list.Sort());

            var fileServiceMock = new Mock<IFileService>();

            var sortService = new NumberSortService(fileServiceMock.Object, sortAlgorithmMock.Object);

            var unsortedNumbers = new List<int> { 5, 2, 8, 1, 6 };
            var sortedNumbers = new List<int> { 1, 2, 5, 6, 8 };


            var result = sortService.SortNumbers(unsortedNumbers);

            sortAlgorithmMock.Verify(sa => sa.Sort(unsortedNumbers), Times.Once);
         
            Assert.Equal(sortedNumbers, result);
        }
        [Fact]
        public void LoadLatestSortedNumbers_ReturnsSortedNumbers_WhenFileExists()
        {
            // Arrange
            var expectedSortedNumbers = new List<int> { 1, 2, 3, 4, 5 };

            var sortAlgorithmMock = new Mock<ISortAlgorithm>();
            sortAlgorithmMock.Setup(sa => sa.Sort(It.IsAny<List<int>>()))
            .Callback<List<int>>(list => list.Sort());

            var fileServiceMock = new Mock<IFileService>();
            fileServiceMock.Setup(fs => fs.LoadFromFile(It.IsAny<string>()))
                .Returns(expectedSortedNumbers);

            var numberSortService = new NumberSortService(fileServiceMock.Object, sortAlgorithmMock.Object);

            var result = numberSortService.LoadLatestSortedNumbers();

            Assert.Equal(expectedSortedNumbers, result);
        }

    }
}
