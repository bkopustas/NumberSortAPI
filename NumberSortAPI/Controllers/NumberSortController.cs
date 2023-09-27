using Microsoft.AspNetCore.Mvc;
using NumberSortAPI.Services;

namespace NumberSortAPI.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class NumberSortController : ControllerBase
    {
        private readonly NumberSortService _numberSortService;

        public NumberSortController(NumberSortService numberSortService)
        {
            _numberSortService = numberSortService;
        }

        [HttpPost("sort")]
        public IActionResult SortNumbers([FromBody] Models.NumberSortRequest request)
        {
            if (request == null || request.Numbers == null || request.Numbers.Count == 0)
            {
                return BadRequest("Invalid input.");
            }

            try
            {
                var sortedNumbers = _numberSortService.SortNumbers(request.Numbers);
                return Ok(sortedNumbers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("latest")]
        public ActionResult<List<int>> LoadLatestSortedNumbers()
        {
            try
            {
                var latestSortedNumbers = _numberSortService.LoadLatestSortedNumbers();
                return Ok(latestSortedNumbers); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
