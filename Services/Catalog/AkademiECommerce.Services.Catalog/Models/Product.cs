using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AkademiECommerce.Services.Catalog.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int Stock { get; set; }
    }
}
