using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PropChecker.Backend.Models;

namespace PropChecker.Backend.Repositories
{
    public class PropertyTraceRepository : IPropertyTraceRepository
    {
        private readonly IMongoCollection<PropertyTrace> _tracesCollection;

        public PropertyTraceRepository(IMongoClient client, IOptions<MongoDbSettings> settings)
        {
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _tracesCollection = database.GetCollection<PropertyTrace>(settings.Value.Collections["PropertyTrace"]);
        }

        public async Task<PropertyTrace> CreateAsync(PropertyTrace newTrace)
        {
            await _tracesCollection.InsertOneAsync(newTrace);
            return newTrace;
        }

        public async Task<List<PropertyTrace>> GetTracesByPropertyIdAsync(string propertyId)
        {
            return await _tracesCollection.Find(x => x.IdProperty == propertyId).ToListAsync();
        }
    }
}