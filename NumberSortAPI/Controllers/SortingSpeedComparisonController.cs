using Microsoft.AspNetCore.Mvc;
using NumberSortAPI.Services;
using NumberSortAPI.SortingAlgorithms;

namespace NumberSortAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SortingSpeedComparisonController : ControllerBase
    {
        private readonly SortingSpeedComparisonService _sortingSpeedComparisonService;

        public SortingSpeedComparisonController(SortingSpeedComparisonService sortingBenchmarkService)
        {
            _sortingSpeedComparisonService = sortingBenchmarkService;
        }

        [HttpPost("benchmark")]
        public IActionResult BenchmarkSortingAlgorithms([FromBody] List<int> numbers)
        {
            if (numbers == null || numbers.Count == 0)
            {
                return BadRequest("Invalid input.");
            }

            try
            {
                
                var result = new Models.SortingSpeedComparisonResult();

                var bubbleSort = new BubbleSort();
                var countingSort = new CountingSort();

                result.BubbleSortTime = _sortingSpeedComparisonService.MeasureSort(numbers, bubbleSort.Sort);

                result.CountingSortTime = _sortingSpeedComparisonService.MeasureSort(numbers, countingSort.Sort);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}

