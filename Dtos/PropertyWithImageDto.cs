using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PropChecker.Backend.Dtos
{
    public class PropertyWithImageDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string CodeInternal { get; set; } = string.Empty;

        public int? Year { get; set; }

        public string? Image { get; set; }
    }
}