using FluentValidation;
using MyFilms.WebAPI.Models.Requests;

namespace MyFilms.WebAPI.Validators
{
    public class RequestValidator : AbstractValidator<CreateOrEditRequest>
    {
        public RequestValidator()
        {
            RuleFor(film => film.Id)
                .NotEmpty().WithMessage("Id is required!");
            RuleFor(film => film.Title)
               .NotEmpty().WithMessage("Title is required!")
               .MaximumLength(200).WithMessage("Max length of title is 200");
            RuleFor(comment => comment.Description)
               .NotEmpty().WithMessage("Description is required!")
               .MaximumLength(2000).WithMessage("Max length of description is 1000"); ;
            RuleFor(comment => comment.CreationYear)
               .LessThanOrEqualTo(2100).WithMessage("Year of creation can't be greater then 2100")
               .GreaterThanOrEqualTo(1900).WithMessage("Year of creation can't be less then 1900");
        }
    }
}
