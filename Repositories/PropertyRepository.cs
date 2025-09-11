using MongoDB.Driver;
using PropChecker.Backend.Models;
using Microsoft.Extensions.Options;

namespace PropChecker.Backend.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly IMongoCollection<Property> _propertiesCollection;

        public PropertyRepository(IMongoClient client, IOptions<MongoDbSettings> settings)
        {
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _propertiesCollection = database.GetCollection<Property>("Property");
        }

        public async Task<List<Property>> GetAllPropertiesAsync()
        {
            return await _propertiesCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Property> GetPropertyByIdAsync(string id)
        {
            return await _propertiesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Property> CreatePropertyAsync(Property newProperty)
        {
            await _propertiesCollection.InsertOneAsync(newProperty);
            return newProperty;
        }

        public async Task UpdatePropertyAsync(string id, Property updatedProperty)
        {
            await _propertiesCollection.ReplaceOneAsync(x => x.Id == id, updatedProperty);
        }

        public async Task RemovePropertyAsync(string id)
        {
            await _propertiesCollection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
