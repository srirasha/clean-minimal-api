using Application._Common.Repositories;
using AutoMapper;
using Domain.Assets;
using Infrastructure.Persistence.Contexts.AssetsDb;
using Infrastructure.Persistence.Contexts.AssetsDb.Entities;
using MongoDB.Driver;

namespace Infrastructure.Persistence.Repositories
{
    public class AvatarsRepository : IAvatarsRepository
    {
        private readonly IAssetsContext _assetsContext;
        private readonly IMapper _mapper;

        public AvatarsRepository(IAssetsContext assetsContext, IMapper mapper)
        {
            _assetsContext = assetsContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Avatar>> GetAll(CancellationToken cancellationToken)
        {
            IEnumerable<AvatarDocument> avatars = await _assetsContext.Avatars.Find(doc => true)
                                                                       .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<Avatar>>(avatars);
        }
    }
}
