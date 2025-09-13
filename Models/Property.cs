using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PropChecker.Backend.Models
{
    [BsonIgnoreExtraElements(true)]
    public class Property
    {

    [BsonId]
    public ObjectId MongoId { get; set; }

    [BsonElement("IdProperty")]
    public string IdProperty { get; set; } = string.Empty;

        [BsonElement("Name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("Address")]
        public string Address { get; set; } = string.Empty;

        [BsonElement("Price")]
        public decimal Price { get; set; }

        [BsonElement("CodeInternal")]
        public string CodeInternal { get; set; } = string.Empty;

        [BsonElement("Year")]
        public DateTime Year { get; set; }

        [BsonElement("IdOwner")]
        public string IdOwner { get; set; } = string.Empty;
    }
}