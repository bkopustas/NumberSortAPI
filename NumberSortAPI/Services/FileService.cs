using NumberSortAPI.Interfaces;

namespace NumberSortAPI.Services
{
    public class FileService : IFileService
    {
        public void SaveToFile(string fileName, List<int> numbers)
        {
            File.WriteAllText(fileName, string.Join(" ", numbers));
        }

        public List<int> LoadFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                var content = File.ReadAllText(fileName);
                return content.Split(' ').Select(int.Parse).ToList();
            }
            throw new FileNotFoundException($"Result file '{fileName}' not found.");
        }
    }
}
