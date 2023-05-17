using Api.Core.Services.ServiceA.Dtos;
using Api.Domain.SchemaFirst;
using AutoMapper;

namespace Api.Core.Services.ServiceA.Profiles;

public class TableAProfile : Profile
{
    public TableAProfile()
    {
        CreateMap<TableA, GetByIdDto>()
            .ForMember(r => r.DtoId, i => i.MapFrom(a => a.Id));
    }
}
