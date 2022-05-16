using Infrastructure.Persistence.Contexts.AssetsDb.Entities;
using MongoDB.Driver;

namespace Infrastructure.Persistence.Contexts.AssetsDb
{
    public interface IAssetsContext
    {
        IMongoCollection<AvatarDocument> Avatars { get; }
    }
}