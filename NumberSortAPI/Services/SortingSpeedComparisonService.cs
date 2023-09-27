using System.Diagnostics;

namespace NumberSortAPI.Services
{
    public class SortingSpeedComparisonService
    {
        public TimeSpan MeasureSort(List<int> numbers, Action<List<int>> sortingAlgorithm)
        {
            var stopwatch = Stopwatch.StartNew();
            sortingAlgorithm(numbers);
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }
    }
}
