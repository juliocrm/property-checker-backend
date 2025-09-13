using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PropChecker.Backend.Models
{
    [BsonIgnoreExtraElements(true)]
    public class PropertyTrace
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("IdPropertyTrace")]
        public string PropertyTraceId { get; set; } = string.Empty;

        [BsonElement("IdProperty")]
        public string IdProperty { get; set; } = string.Empty;

        [BsonElement("DateSale")]
        public DateTime DateSale { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("Value")]
        public decimal Value { get; set; }

        [BsonElement("Tax")]
        public decimal Tax { get; set; }
    }
}