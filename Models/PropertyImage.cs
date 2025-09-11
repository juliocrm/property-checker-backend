using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PropChecker.Backend.Models
{
    [BsonIgnoreExtraElements(true)]
    public class PropertyImage
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("IdPropertyImage")]
        public string Id { get; set; } = string.Empty;

        [BsonElement("IdProperty")]
        public string IdProperty { get; set; } = string.Empty;

        [BsonElement("file")]
        public string File { get; set; } = string.Empty;

        [BsonElement("Enabled")]
        public bool Enabled { get; set; }
    }
}