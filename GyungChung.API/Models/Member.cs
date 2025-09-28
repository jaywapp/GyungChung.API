using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Security;

namespace GyungChung.API.Models
{
    public class Member
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string UserID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        [BsonRepresentation(BsonType.String)]
        public ePermission Permission { get; set; }
        public DateTime Birth { get; set; }
        public DateTime Joined { get; set; }
    }
}
