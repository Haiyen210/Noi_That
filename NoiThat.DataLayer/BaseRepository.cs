using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using MongoDB.Bson;
using MongoDB.Driver;
using NoiThat.Services.Entity;
using NoiThat.Services.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace NoiThat.DataLayer
{
    public class BaseRepository<TEntity> : IBaseResponsitory<TEntity> where TEntity : class
    {
        private readonly IMongoCollection<TEntity> _interiorCollection;
        public BaseRepository(IOptions<InteriorDatabaseSettings> interiorDataSettings)
        {
            var mongoClient = new MongoClient(
          interiorDataSettings.Value.ConnectionString);
            var db = mongoClient.GetDatabase(
                interiorDataSettings.Value.DatabaseName);
            _interiorCollection = db.GetCollection<TEntity>(typeof(TEntity).Name);

        }

        public virtual async Task<TEntity> Add(TEntity obj)
        {
            await _interiorCollection.InsertOneAsync(obj);
            return obj;
        }
        public virtual async Task<TEntity> GetById(string id)
        {
            var data = await _interiorCollection.Find(FilterId(id)).SingleOrDefaultAsync();
            return data;
        }

        public async virtual Task<IEnumerable<TEntity>> GetAll()
        {
            var all = await _interiorCollection.Find(_=>true).ToListAsync();
            return all;
        }

        public async virtual Task<TEntity> Update(string id, TEntity obj)
        {
            await _interiorCollection.ReplaceOneAsync(FilterId(id), obj);
            return obj;
        }

        public async virtual Task<bool> Remove(string id)
        {
            var result = await _interiorCollection.DeleteOneAsync(FilterId(id));
            return result.IsAcknowledged;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        private static FilterDefinition<TEntity> FilterId(string key)
        {
            return Builders<TEntity>.Filter.Eq("_id", key);
        }
    }
}
