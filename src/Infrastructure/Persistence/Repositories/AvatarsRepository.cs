using Application._Common.Repositories;
using Domain.Assets;
using Infrastructure.Persistence.Contexts.AssetsDb;
using Infrastructure.Persistence.Contexts.AssetsDb.Entities;
using MongoDB.Driver;

namespace Infrastructure.Persistence.Repositories
{
    public class AvatarsRepository : IAvatarsRepository
    {
        private readonly IAssetsContext _assetsContext;

        public AvatarsRepository(IAssetsContext assetsContext)
        {
            _assetsContext = assetsContext;
        }

        public async Task<IEnumerable<Avatar>> GetAll(CancellationToken cancellationToken)
        {
            List<AvatarDocument> avatars = await _assetsContext.Avatars.Find(doc => true)
                                                                       .ToListAsync(cancellationToken);

            return avatars.Select(avatar => new Avatar());
        }
    }
}
