using MongoDB.Driver;

namespace GyungChung.API.Services
{
    public class MongoService<T>
    {
        private readonly IMongoCollection<T> _collection;

        public MongoService(IMongoDatabase database, string collectionName)
        {
            _collection = database.GetCollection<T>(collectionName);
        }

        public async Task<List<T>> GetAllAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task<T> GetByIdAsync(string idField, string idValue)
        {
            var filter = Builders<T>.Filter.Eq(idField, idValue);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(T entity) =>
            await _collection.InsertOneAsync(entity);

        public async Task UpdateAsync(string idField, string idValue, T entity)
        {
            var filter = Builders<T>.Filter.Eq(idField, idValue);
            await _collection.ReplaceOneAsync(filter, entity);
        }

        public async Task DeleteAsync(string idField, string idValue)
        {
            var filter = Builders<T>.Filter.Eq(idField, idValue);
            await _collection.DeleteOneAsync(filter);
        }
    }
}
