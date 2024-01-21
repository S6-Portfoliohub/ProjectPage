using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DAOInterfaces.DTO
{
    public class ShowcaseItemDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? ProjectId { get; set; }
        public string? UserId { get; set; }
        public string? type { get; set; }
        public string? Description { get; set; }
        public string? Img { get; set; }
    }
}
