using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PropChecker.Backend.Models
{
    [BsonIgnoreExtraElements(true)]
    public class Owner
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("IdOwner")]
        public string Id { get; set; } = string.Empty;

        [BsonElement("Name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("Address")]
        public string Address { get; set; } = string.Empty;

        [BsonElement("Photo")]
        public string Photo { get; set; } = string.Empty;

        [BsonElement("Birthday")]
        public DateTime Birthday { get; set; }
    }
}