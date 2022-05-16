using Application._Common.Repositories;
using CSharpFunctionalExtensions;
using Domain.Assets;
using MediatR;

namespace Application.Avatars.Queries.GetAvatarById
{
    public class GetAvatarByIdQueryHandler : IRequestHandler<GetAvatarByIdQuery, Maybe<Avatar>>
    {
        private readonly IAvatarsRepository _avatarsRepository;

        public GetAvatarByIdQueryHandler(IAvatarsRepository avatarsRepository)
        {
            _avatarsRepository = avatarsRepository;
        }

        public async Task<Maybe<Avatar>> Handle(GetAvatarByIdQuery request, CancellationToken cancellationToken)
        {
            return await _avatarsRepository.GetById(request.Id, cancellationToken);
        }
    }
}