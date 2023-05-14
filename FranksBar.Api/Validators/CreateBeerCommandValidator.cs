using FluentValidation;
using FranksBar.Shared.Commands;

namespace FranksBar.Api.Validators
{
    public class CreateBeerCommandValidator : AbstractValidator<CreateBeerCommand>
    {
        public CreateBeerCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Please specify name of the beer.");

            RuleFor(x => x.PercentageAlcoholByVolume)
                .NotNull()
                .NotEmpty()
                .GreaterThan(-1)
                .LessThan(100)
                .WithMessage("Please specify a valid percentage of alcohol");
        }
    }
}
