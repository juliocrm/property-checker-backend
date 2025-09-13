using PropChecker.Backend.Dtos;
using PropChecker.Backend.Repositories;

namespace PropChecker.Backend.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;

        public PropertyService(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public async Task<List<PropertyWithImageDto>> GetPropertiesByFiltersAsync(string? name, string? address, decimal? minPrice, decimal? maxPrice)
        {
            return await _propertyRepository.GetPropertiesWithImagesAsync(name, address, minPrice, maxPrice);
        }
    }
}

