using Application._Common.Repositories;
using AutoMapper;
using CSharpFunctionalExtensions;
using Domain.Assets;
using Infrastructure.Persistence.Contexts.AssetsDb;
using Infrastructure.Persistence.Contexts.AssetsDb.Entities;
using MongoDB.Bson;
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
            IEnumerable<AvatarDocument> avatars = await _assetsContext.Avatars.Find(_ => true)
                                                                              .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<Avatar>>(avatars);
        }

        public async Task<Maybe<Avatar>> GetById(string id, CancellationToken cancellationToken)
        {
            if (!ObjectId.TryParse(id, out ObjectId docId))
            {
                return Maybe<Avatar>.None;
            }

            AvatarDocument avatar = await _assetsContext.Avatars.Find(Builders<AvatarDocument>.Filter.Eq(doc => doc.Id, docId)).FirstOrDefaultAsync(cancellationToken);

            if (avatar == null)
            {
                throw new KeyNotFoundException();
            }

            return Maybe<Avatar>.From(_mapper.Map<Avatar>(avatar));
        }
    }
}