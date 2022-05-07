using Domain.Assets;

namespace Application._Common.Repositories
{
    public interface IAvatarsRepository
    {
        public Task<IEnumerable<Avatar>> GetAll(CancellationToken cancellationToken);
    }
}