using PropChecker.Backend.Models;

namespace PropChecker.Backend.Services
{
    public interface IPropertyService
    {
        Task<List<Property>> GetPropertiesByFiltersAsync(string? name, string? address, decimal? minPrice, decimal? maxPrice);
    }
}
