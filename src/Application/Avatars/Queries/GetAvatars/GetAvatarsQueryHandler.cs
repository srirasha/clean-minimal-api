using Application._Common.Repositories;
using Domain.Assets;
using MediatR;

namespace Application.Avatars.Queries.GetAvatars
{
    public class GetAvatarsQueryHandler : IRequestHandler<GetAvatarsQuery, IEnumerable<Avatar>>
    {
        private readonly IAvatarsRepository _avatarsRepository;

        public GetAvatarsQueryHandler(IAvatarsRepository avatarsRepository)
        {
            _avatarsRepository = avatarsRepository;
        }

        public Task<IEnumerable<Avatar>> Handle(GetAvatarsQuery request, CancellationToken cancellationToken)
        {
            return _avatarsRepository.GetAll(cancellationToken);
        }
    }
}