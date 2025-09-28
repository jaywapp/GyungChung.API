using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace GyungChung.API.Models
{
    public class Location
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string LocationID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public bool Outside { get; set; }
    }
}
