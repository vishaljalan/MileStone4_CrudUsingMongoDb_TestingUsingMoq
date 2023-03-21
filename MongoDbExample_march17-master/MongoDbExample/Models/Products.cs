using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace MongoDbExample.Models
{
    public class Products
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? id { get; set; }

        public string? category { get; set; }

        public string? name { get; set; }

        
        public int? price { get; set; }


    }
}
