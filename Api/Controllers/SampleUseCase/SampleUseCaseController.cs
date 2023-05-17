using Api.Controllers.SampleUseCase.Requests;
using Api.Core.Services.ServiceA;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.SampleUseCase;

[ApiController]
[Route("api/[controller]")]
public class SampleUseCaseController : ControllerBase
{
    private readonly IServiceA _serviceA;

    public SampleUseCaseController(IServiceA serviceA) => _serviceA = serviceA;

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(int id) => Ok(await _serviceA.GetById(id));

    [HttpPost("ValidateSampleRequest")]
    public IActionResult ValidateSampleRequest(SampleRequest request) => Ok();
}
