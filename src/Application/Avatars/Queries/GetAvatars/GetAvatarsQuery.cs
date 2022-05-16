using Domain.Assets;
using MediatR;

namespace Application.Avatars.Queries.GetAvatars
{
    public class GetAvatarsQuery : IRequest<IEnumerable<Avatar>>
    {
    }
}