using Api.Core.Services.ServiceA.Dtos;

namespace Api.Core.Services.ServiceA;

public interface IServiceA
{
    Task<GetByIdDto> GetById(int id);
}
