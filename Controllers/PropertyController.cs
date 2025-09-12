using Microsoft.AspNetCore.Mvc;
using PropChecker.Backend.Dtos;
using PropChecker.Backend.Services;

namespace PropChecker.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PropertyWithImageDto>>> GetProperties(
            [FromQuery] string? name,
            [FromQuery] string? address,
            [FromQuery] decimal? minPrice,
            [FromQuery] decimal? maxPrice)
        {
            var properties = await _propertyService.GetPropertiesByFiltersAsync(name, address, minPrice, maxPrice);

            if (properties == null || !properties.Any())
            {
                return NotFound();
            }

            return Ok(properties);
        }
    }
}
