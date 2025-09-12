using MongoDB.Bson;
using MongoDB.Driver;
using PropChecker.Backend.Dtos;
using PropChecker.Backend.Models;
using Microsoft.Extensions.Options;

namespace PropChecker.Backend.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly IMongoCollection<Property> _propertiesCollection;
        private readonly string _propertyImagesCollectionName;

        public PropertyRepository(IMongoClient client, IOptions<MongoDbSettings> settings)
        {
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _propertiesCollection = database.GetCollection<Property>(settings.Value.Collections["Properties"]);
            _propertyImagesCollectionName = settings.Value.Collections["PropertyImages"];
        }

        public async Task<List<PropertyWithImageDto>> GetPropertiesWithImagesAsync(string? name, string? address, decimal? minPrice, decimal? maxPrice)
        {
            var filterBuilder = Builders<Property>.Filter;
            var filter = filterBuilder.Empty;

            if (!string.IsNullOrEmpty(name))
            {
                filter &= filterBuilder.Regex(p => p.Name, new BsonRegularExpression(name, "i"));
            }
            if (!string.IsNullOrEmpty(address))
            {
                filter &= filterBuilder.Regex(p => p.Address, new BsonRegularExpression(address, "i"));
            }
            if (minPrice.HasValue)
            {
                filter &= filterBuilder.Gte(p => p.Price, minPrice.Value);
            }
            if (maxPrice.HasValue)
            {
                filter &= filterBuilder.Lte(p => p.Price, maxPrice.Value);
            }

            var pipeline = _propertiesCollection.Aggregate()
                .Match(filter)
                .Lookup(
                    foreignCollectionName: _propertyImagesCollectionName,
                    localField: "IdProperty",
                    foreignField: "IdProperty",
                    @as: "Images"
                )
                .Unwind("Images", new AggregateUnwindOptions<BsonDocument> { PreserveNullAndEmptyArrays = true })
                .Project<PropertyWithImageDto>(new BsonDocument
                {
                    { "_id", "$IdProperty" },
                    { "Name", "$Name" },
                    { "Address", "$Address" },
                    { "Price", "$Price" },
                    { "CodeInternal", "$CodeInternal" },
                    { "Year", new BsonDocument("$year", "$Year") },
                    { "Image", "$Images.file" }
                });

            return await pipeline.ToListAsync();
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
