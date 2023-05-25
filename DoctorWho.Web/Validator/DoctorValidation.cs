using DoctorWho.Web.DTOs.DoctorsDTOs;
using FluentValidation;

namespace DoctorWho.Web.Validator;

public class DoctorValidation : AbstractValidator<Doctor>
{
    public DoctorValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("The name is required");
        RuleFor(x => x.Number)
            .NotEmpty()
            .WithMessage("The number is required");
        RuleFor(x => x.FirstEpisodeDate)
            .NotEmpty()
            .WithMessage("The firstEpisodeDate is required");
        RuleFor(e => e.LastEpisodeDate)
           .GreaterThanOrEqualTo(e => e.FirstEpisodeDate)
           .WithMessage("Last episode date must be greater than or equal to the first episode date.");
    }
}
