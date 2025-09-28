using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace GyungChung.API.Models
{
    public class Schedule
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string ScheduleID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LocationID { get; set; }
        public DateTime DateTime { get; set; }
        public List<string> Attendees { get; set; } = new List<string>();
    }
}
