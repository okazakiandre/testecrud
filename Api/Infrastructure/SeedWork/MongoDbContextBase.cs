using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace TesteCrud.Api.Infrastructure.SeedWork
{
    public abstract class MongoDbContextBase
    {
        public IMongoDatabase Database { get; }
        protected MongoDbContextBase(IConfiguration config)
        {
            string cn = config.GetSection("mongoDb")["connectionString"];
            var settings = MongoClientSettings.FromUrl(new MongoUrl(cn));
            MongoClient mc = new MongoClient(settings);
            Database = mc.GetDatabase(new MongoUrl(cn).DatabaseName);
        }

        protected abstract void OnRegisterMappers();

        protected virtual void RegisterClassMap<Entity, Mapper>() where Mapper : BsonClassMap<Entity>, new()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(Entity)))
            {
                BsonClassMap.RegisterClassMap(new Mapper());
            }
        }
    }
}
