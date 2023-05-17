using FluentValidation;

namespace Api.Controllers.SampleUseCase.Requests;

public record SampleRequest 
{
    public string Name { get; set; }
    public string Email { get; set; }
}

public class SampleRequestValidator : AbstractValidator<SampleRequest>
{
    public SampleRequestValidator()
    {
        RuleFor(p => p.Name).NotEmpty().WithMessage("X is required.");
        RuleFor(p => p.Email).NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Email is not valid.");
    }
}
