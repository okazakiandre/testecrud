using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using TesteCrud.Api.Domain;
using TesteCrud.Api.Infrastructure.SeedWork;

namespace TesteCrud.Api.Infrastructure.Repositories
{
    public class ClienteDbContext : MongoDbContextBase, IMongoDbContext
    {
        public ClienteDbContext(IConfiguration config) : base(config)
        {
            OnRegisterMappers();
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return Database.GetCollection<T>(collectionName);
        }

        protected override void OnRegisterMappers()
        {
            RegisterClassMap<Cliente, ClienteDbMapper>();
        }

    }
}
