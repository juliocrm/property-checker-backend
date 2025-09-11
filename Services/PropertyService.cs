using PropChecker.Backend.Models;
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

        public async Task<List<Property>> GetPropertiesByFiltersAsync(string? name, string? address, decimal? minPrice, decimal? maxPrice)
        {
            var properties = await _propertyRepository.GetAllPropertiesAsync();

            var filteredProperties = properties.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                filteredProperties = filteredProperties.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(address))
            {
                filteredProperties = filteredProperties.Where(p => p.Address.Contains(address, StringComparison.OrdinalIgnoreCase));
            }

            if (minPrice.HasValue)
            {
                filteredProperties = filteredProperties.Where(p => p.Price >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                filteredProperties = filteredProperties.Where(p => p.Price <= maxPrice.Value);
            }

            return filteredProperties.ToList();
        }
    }
}
