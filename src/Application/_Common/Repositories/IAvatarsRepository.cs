using CSharpFunctionalExtensions;
using Domain.Assets;

namespace Application._Common.Repositories
{
    public interface IAvatarsRepository
    {
        public Task<IEnumerable<Avatar>> GetAll(CancellationToken cancellationToken = default);

        public Task<Maybe<Avatar>> GetById(string id, CancellationToken cancellationToken = default);
    }
}