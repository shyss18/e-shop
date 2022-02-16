using System.Linq.Expressions;

namespace ES.ProductService.Infrastructure.Repository;

public interface IGenericRepository<TEntity>
{
    Task CreateAsync(TEntity entity, CancellationToken cancellationToken);

    Task ChangeAsync(TEntity entity, CancellationToken cancellationToken);

    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken);

    Task<TEntity[]> GetRangeAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken);
}