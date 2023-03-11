using FluentValidation;

namespace Application.Feautres.Authors.Commands.CreateAuthorCommand
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .Empty().WithMessage("{PropertyName} no debe estar vacio")
                .MaximumLength(120).WithMessage("{PropertyName} no debe ser mayor a {MaxLength}");

            RuleFor(x => x.LastName)
                .Empty().WithMessage("{PropertyName} no debe estar vacio")
                .MaximumLength(120).WithMessage("{PropertyName} no debe ser mayor a {MaxLength}");
        }
    }
}
