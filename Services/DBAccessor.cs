using GyungChung.Core.Models;
using MongoDB.Driver;

namespace GyungChung.API.Services
{
    public class DBAccessor
    {
        private const string URL = "mongodb://192.168.0.101:27017/";
        private const string DB_NAME = "GyungChung";

        private const string COLLECTION_MEMBERS = "Members";
        private const string COLLECTION_LOCATIONS = "Locations";
        private const string COLLECTION_SCHEDULES = "Schedules";

        private MongoClient _client;
        private IMongoDatabase _db;
        private IMongoCollection<Member> _memberCollection;
        private IMongoCollection<Location> _locationCollection;
        private IMongoCollection<Schedule> _scheduleCollection;

        public DBAccessor()
        {
            _client = new MongoClient(URL);
            _db = _client.GetDatabase(DB_NAME);

            _memberCollection = _db.GetCollection<Member>(COLLECTION_MEMBERS);
            _locationCollection = _db.GetCollection<Location>(COLLECTION_LOCATIONS);
            _scheduleCollection = _db.GetCollection<Schedule>(COLLECTION_SCHEDULES);
        }

        public async Task<List<Member>> GetMembersAsync()
        {
            var fluent = _memberCollection.Find(Builders<Member>.Filter.Empty);
            var members = await fluent.ToListAsync();

            return members;
        }
    }
}
