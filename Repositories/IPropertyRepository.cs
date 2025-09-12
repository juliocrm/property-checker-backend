using PropChecker.Backend.Dtos;
using PropChecker.Backend.Models;

namespace PropChecker.Backend.Repositories
{
    public interface IPropertyRepository
    {
        Task<List<PropertyWithImageDto>> GetPropertiesWithImagesAsync(string? name, string? address, decimal? minPrice, decimal? maxPrice);
        Task<Property> GetPropertyByIdAsync(string id);
        Task<Property> CreatePropertyAsync(Property newProperty);
        Task UpdatePropertyAsync(string id, Property updatedProperty);
        Task RemovePropertyAsync(string id);
    }
}
