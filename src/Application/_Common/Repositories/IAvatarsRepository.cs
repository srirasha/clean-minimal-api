using CSharpFunctionalExtensions;
using Domain.Assets;

namespace Application._Common.Repositories
{
    public interface IAvatarsRepository
    {
        public Task<IEnumerable<Avatar>> GetAll(CancellationToken cancellationToken);

        public Task<Maybe<Avatar>> GetById(string id, CancellationToken cancellationToken);
    }
}