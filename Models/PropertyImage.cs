using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PropChecker.Backend.Models
{
    public class PropertyImage
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        public string IdProperty { get; set; } = string.Empty;

        public byte[] File { get; set; } = Array.Empty<byte>();

        public bool Enabled { get; set; }
    }
}
