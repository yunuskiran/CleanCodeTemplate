using Ardalis.Specification;

namespace Api.Domain.SchemaFirst;

public interface ISchemaFirstRepository<T> : IRepositoryBase<T> where T : class
{
}
