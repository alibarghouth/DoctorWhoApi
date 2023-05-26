using DoctorWho.Web.DTOs.EpisodeDTOs;
using FluentValidation;

namespace DoctorWho.Web.Validator;

public sealed class EpisodeValidation : AbstractValidator<Episode>
{
    public EpisodeValidation()
    {
        RuleFor(x => x.AuthorId)
            .NotEmpty().WithMessage("The Author is required"); ;
        RuleFor(x => x.DoctorId)
            .NotEmpty().WithMessage("The Doctor is required"); ;
        RuleFor(e => e.SeriesNumber)
            .NotEmpty().WithMessage("The SeriesNumber should not be empty.")
            .Length(10).WithMessage("The SeriesNumber should be exactly 10 characters long.");
        RuleFor(e => e.EpisodeNumber)
           .NotEmpty().WithMessage("The EpisodeNumber should be greater than 0.")
           .GreaterThan(0);
    }
}
