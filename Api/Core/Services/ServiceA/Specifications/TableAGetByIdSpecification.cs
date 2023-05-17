using Api.Domain.SchemaFirst;
using Ardalis.Specification;

namespace Api.Core.Services.ServiceA.Specifications;

public sealed class TableAGetByIdSpecification : Specification<TableA>
{
    public TableAGetByIdSpecification(int id)
    {
        Query.Where(_ => _.Id == id);
    }
}
