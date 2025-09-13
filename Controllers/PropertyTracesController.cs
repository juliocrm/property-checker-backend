using Microsoft.AspNetCore.Mvc;
using PropChecker.Backend.Models;
using PropChecker.Backend.Repositories;

namespace PropChecker.Backend.Controllers
{
    [ApiController]
    [Route("api")]
    public class PropertyTracesController : ControllerBase
    {
        private readonly IPropertyTraceRepository _traceRepository;
        private readonly IPropertyRepository _propertyRepository;

        public PropertyTracesController(IPropertyTraceRepository traceRepository, IPropertyRepository propertyRepository)
        {
            _traceRepository = traceRepository;
            _propertyRepository = propertyRepository;
        }

        [HttpPost("propertytraces")]
        public async Task<IActionResult> CreateTrace([FromBody] PropertyTrace newTrace)
        {
            if (newTrace == null || string.IsNullOrEmpty(newTrace.IdProperty))
            {
                return BadRequest("PropertyTrace data is invalid or IdProperty is missing.");
            }

            var property = await _propertyRepository.GetPropertyByIdAsync(newTrace.IdProperty);
            if (property == null)
            {
                return NotFound($"Property with ID '{newTrace.IdProperty}' not found.");
            }

            var createdTrace = await _traceRepository.CreateAsync(newTrace);
            return CreatedAtAction(nameof(GetTracesByProperty), new { propertyId = createdTrace.IdProperty }, createdTrace);
        }

        [HttpGet("properties/{propertyId}/traces")]
        public async Task<ActionResult<List<PropertyTrace>>> GetTracesByProperty(string propertyId)
        {
            return await _traceRepository.GetTracesByPropertyIdAsync(propertyId);
        }
    }
}