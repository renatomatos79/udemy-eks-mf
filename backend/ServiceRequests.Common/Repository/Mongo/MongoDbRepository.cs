using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using ServiceRequests.Common.Model.Db;
using ServiceRequests.Common.Model.Settings;
using System.Linq.Expressions;

namespace ServiceRequests.Common.Repository.Mongo;


    public class MongoDbRepository<TEntity> : IMongoDbRepository<TEntity> where TEntity : EntityBase
    {
        private IDbSettngs _dbSettings;
        private MongoDatabase _database;
        protected MongoCollection<TEntity> _collection;

        public MongoDbRepository(IDbSettngs dbSettings, string collectionName)
        {
            _dbSettings = dbSettings;
            _database = GetDatabase();
            _collection = GetCollection(collectionName);
        }

        public Guid Insert(TEntity entity)
        {
            _collection.Insert(entity);
            return entity.Id;
        }

        public bool Update(TEntity entity)
        {
            return _collection.Save(entity).DocumentsAffected > 0;
        }

        public bool Delete(TEntity entity)
        {
            return _collection.Remove(Query.EQ("_id", entity.Id)).DocumentsAffected > 0;
        }

        public IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return _collection.AsQueryable().Where(predicate.Compile()).AsParallel();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _collection.FindAllAs<TEntity>();
        }

        public TEntity? GetById(Guid id)
        {
            return _collection.FindOneByIdAs<TEntity>(id);
        }

        #region Private Helper Methods  
        private MongoDatabase GetDatabase()
        {
            var client = new MongoClient(_dbSettings.ConnectionString);
            var server = client.GetServer();
            return server.GetDatabase(_dbSettings.DBName);
        }

        private MongoCollection<TEntity> GetCollection(string colllectionName)
        {
            return _database.GetCollection<TEntity>(colllectionName);
        }
        #endregion
    }

