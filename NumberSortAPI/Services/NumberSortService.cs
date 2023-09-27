using NumberSortAPI.Interfaces;

namespace NumberSortAPI.Services
{

    public class NumberSortService
    {
        private const string FileName = "result.txt";
        private readonly IFileService _fileService;
        private readonly ISortAlgorithm _sortAlgorithm;

        public NumberSortService() { }

        public NumberSortService(IFileService fileService, ISortAlgorithm sortAlgorithm)
        {
            _fileService = fileService;
            _sortAlgorithm = sortAlgorithm;
        }
        public List<int> SortNumbers(List<int> numbers)
        {

            _sortAlgorithm.Sort(numbers);

            _fileService.SaveToFile(FileName, numbers);
            return numbers;
        }

        public List<int> LoadLatestSortedNumbers()
        {
            try
            {
                return _fileService.LoadFromFile(FileName);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to load sorted numbers.", ex);
            }
        }
    }
}
