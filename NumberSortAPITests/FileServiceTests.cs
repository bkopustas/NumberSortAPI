using NumberSortAPI.Services;
using Xunit;

namespace NumberSortAPITests
{
    public class FileServiceTests
    {
        [Fact]
        public void ShouldWriteDataToFileCorrectly()
        {
            const string fileName = "resultTest.txt";
            var fileService = new FileService();

            var numbersToSave = new List<int> { 1, 2, 3, 4, 5 };

            fileService.SaveToFile(fileName, numbersToSave);

            Assert.True(File.Exists(fileName));
            var fileContent = File.ReadAllText(fileName);
            Assert.Equal("1 2 3 4 5", fileContent);

            File.Delete(fileName);
        }

        [Fact]
        public void ShouldLoadDataFromFile()
        {
            const string fileName = "resultTest.txt";
            var fileService = new FileService();

            File.WriteAllText(fileName, "5 4 3 2 1");

            var loadedNumbers = fileService.LoadFromFile(fileName);

            Assert.Equal(new List<int> { 5, 4, 3, 2, 1 }, loadedNumbers);

            File.Delete(fileName);
        }

        [Fact]
        public void LoadFromFile_ShouldThrowFileNotFoundException_WhenFileDoesNotExist()
        {
            const string fileName = "nonexistentfile.txt";
            var fileService = new FileService();

            Assert.Throws<FileNotFoundException>(() => fileService.LoadFromFile(fileName));
        }
    }
}
