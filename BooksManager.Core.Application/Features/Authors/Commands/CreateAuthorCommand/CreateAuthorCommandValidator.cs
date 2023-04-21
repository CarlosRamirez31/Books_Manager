using FluentValidation;

namespace Application.Features.Authors.Commands.CreateAuthorCommand
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("{PropertyName} no debe estar vacio")
                .MaximumLength(120).WithMessage("{PropertyName} no debe ser mayor a {MaxLength}");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("{PropertyName} no debe estar vacio")
                .MaximumLength(120).WithMessage("{PropertyName} no debe ser mayor a {MaxLength}");
        }
    }
}
