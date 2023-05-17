using Api.Domain.SchemaFirst;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure.Data.SchemaSecond;

public class SchemaSecondRepository<T> : RepositoryBase<T>, ISchemaFirstRepository<T>
    where T : class
{
    private readonly DbContext _dbContext;

    public SchemaSecondRepository(DbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Reload(T entity) => await _dbContext.Entry(entity).ReloadAsync();
}

