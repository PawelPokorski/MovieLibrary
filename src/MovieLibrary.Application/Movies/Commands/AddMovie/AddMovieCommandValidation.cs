using FluentValidation;

namespace MovieLibrary.Application.Movies.Commands.AddMovie;

public class AddMovieCommandValidation : AbstractValidator<AddMovieCommand>
{
    public AddMovieCommandValidation()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(100).WithMessage("Title cannot be longer than 200 characters.");

        RuleFor(x => x.Year)
            .GreaterThanOrEqualTo((short)1801).WithMessage("Year must be greater than or equal to 1801.")
            .LessThanOrEqualTo((short)2155).WithMessage("Year must be less than or equal to 2155.")
            .When(x => x.Year != 0); // Year is optional, so validate only when not default
    }
}