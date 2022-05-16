using Infrastructure.Persistence.Contexts.AssetsDb.Configurations;
using Infrastructure.Persistence.Contexts.AssetsDb.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure.Persistence.Contexts.AssetsDb
{
    public class AssetsContext : IAssetsContext
    {
        private readonly IMongoDatabase _database;

        public AssetsContext(IOptions<AssetsDbConfiguration> assetsDbOptions)
        {
            MongoClient _mongoClient = new(assetsDbOptions.Value.ConnectionString);
            _database = _mongoClient.GetDatabase(assetsDbOptions.Value.Database);
        }

        public IMongoCollection<AvatarDocument> Avatars => _database.GetCollection<AvatarDocument>("avatars");
    }
}
