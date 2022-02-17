using System.Linq.Expressions;
using AutoMapper;
using ES.ProductService.Application.Contracts.Repositories;
using ES.ProductService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ES.ProductService.Infrastructure.Repositories;

public class GenericRepository<TEntity, TModel> : IGenericRepository<TEntity> where TModel : class
{
    private readonly IMapper _mapper;
    private readonly ApplicationContext _applicationContext;

    public GenericRepository(
        IMapper mapper,
        ApplicationContext applicationContext)
    {
        _mapper = mapper;
        _applicationContext = applicationContext;
    }

    public Task CreateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<TModel>(entity);
        _applicationContext.Set<TModel>().Add(model);
        return _applicationContext.SaveChangesAsync(cancellationToken);
    }

    public Task ChangeAsync(TEntity entity, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<TModel>(entity);
        _applicationContext.Set<TModel>().Update(model);
        return _applicationContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken)
    {
        var modelExpression = _mapper.Map<Expression<Func<TModel, bool>>>(expression);
        var result = await _applicationContext
            .Set<TModel>()
            .FirstOrDefaultAsync(modelExpression, cancellationToken);

        return _mapper.Map<TEntity>(result);
    }

    public async Task<TEntity[]> GetRangeAsync(Expression<Func<TEntity, bool>> expression,
        CancellationToken cancellationToken)
    {
        var modelExpression = _mapper.Map<Expression<Func<TModel, bool>>>(expression);
        var result = await _applicationContext
            .Set<TModel>()
            .AsNoTracking()
            .Where(modelExpression)
            .ToArrayAsync(cancellationToken);

        return _mapper.Map<TEntity[]>(result);
    }
}