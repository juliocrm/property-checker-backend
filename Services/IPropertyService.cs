using PropChecker.Backend.Dtos;

namespace PropChecker.Backend.Services
{
    public interface IPropertyService
    {
        Task<List<PropertyWithImageDto>> GetPropertiesByFiltersAsync(string? name, string? address, decimal? minPrice, decimal? maxPrice);
    }
}
