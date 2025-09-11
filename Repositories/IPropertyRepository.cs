using PropChecker.Backend.Models;

namespace PropChecker.Backend.Repositories
{
    public interface IPropertyRepository
    {
        Task<List<Property>> GetAllPropertiesAsync();
        Task<Property> GetPropertyByIdAsync(string id);
        Task<Property> CreatePropertyAsync(Property newProperty);
        Task UpdatePropertyAsync(string id, Property updatedProperty);
        Task RemovePropertyAsync(string id);
    }
}
