using PropChecker.Backend.Models;

namespace PropChecker.Backend.Repositories
{
    public interface IPropertyTraceRepository
    {
        Task<PropertyTrace> CreateAsync(PropertyTrace newTrace);
        Task<List<PropertyTrace>> GetTracesByPropertyIdAsync(string propertyId);
    }
}