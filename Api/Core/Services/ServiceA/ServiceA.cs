using Api.Core.Services.ServiceA.Dtos;
using Api.Core.Services.ServiceA.Specifications;
using Api.Domain.SchemaFirst;
using AutoMapper;

namespace Api.Core.Services.ServiceA;

public class ServiceA : IServiceA
{
    private readonly IMapper _mapper;
    private readonly ISchemaFirstRepository<TableA> _schemaFirstRepository;

    public ServiceA(IMapper mapper,
        ISchemaFirstRepository<TableA> schemaFirstRepository)
    {
        _mapper = mapper;
        _schemaFirstRepository = schemaFirstRepository;
    }

    public async Task<GetByIdDto> GetById(int id)
        => _mapper.Map<GetByIdDto>(
                await _schemaFirstRepository.FirstOrDefaultAsync(new TableAGetByIdSpecification(id))
            );
}
