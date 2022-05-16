using CSharpFunctionalExtensions;
using Domain.Assets;
using MediatR;

namespace Application.Avatars.Queries.GetAvatarById
{
    public class GetAvatarByIdQuery : IRequest<Maybe<Avatar>>
    {
        public GetAvatarByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}