using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace api_train_orm.Models
{
    public class Pizza
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; } = null!;

        [BsonElement("IsGlutenFree")]
        public bool IsGlutenFree { get; set; }
    }
}
