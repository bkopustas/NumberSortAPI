namespace NumberSortAPI.Interfaces
{
    public interface IFileService
    {
        void SaveToFile(string fileName, List<int> numbers);
        List<int> LoadFromFile(string fileName);
    }
}
