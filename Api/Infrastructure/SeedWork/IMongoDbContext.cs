using MongoDB.Driver;

namespace TesteCrud.Api.Infrastructure.SeedWork
{
    public interface IMongoDbContext
    {
        IMongoCollection<T> GetCollection<T>(string collectionName);
    }
}
