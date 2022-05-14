using CSharpFunctionalExtensions;
using System.Linq.Expressions;

namespace Application._Common.Repositories.BaseRepository
{
    public interface IBaseRepository<TEntity>
    {
        Task DeleteById(string id, CancellationToken cancellationToken);

        Task DeleteMany(Expression<Func<TEntity, bool>> filterExpression, CancellationToken cancellationToken);

        Task DeleteOne(Expression<Func<TEntity, bool>> filterExpression, CancellationToken cancellationToken);

        Task<IEnumerable<TEntity>> FilterBy(Expression<Func<TEntity, bool>> filterExpression, CancellationToken cancellationToken);

        Task<Maybe<TEntity>> FindOne(Expression<Func<TEntity, bool>> filterExpression, CancellationToken cancellationToken);

        Task<Maybe<TEntity>> FindById(string id, CancellationToken cancellationToken);

        Task<TEntity> InsertOne(TEntity document, CancellationToken cancellationToken);

        Task<ICollection<TEntity>> InsertMany(ICollection<TEntity> documents, CancellationToken cancellationToken);

        Task ReplaceOne(TEntity document, CancellationToken cancellationToken);
    }
}