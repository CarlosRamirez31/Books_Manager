using FluentValidation;

namespace BooksManager.Core.Application.Feautres.Users.Commands.RegisterCommand
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("{PropertyName} no puede ser no puede estar vacio")
                .MaximumLength(80).WithMessage("{PropertyName} no puede ser mayor a {MaxLength}");
            
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("{PropertyName} no puede ser no puede estar vacio")
                .MaximumLength(120).WithMessage("{PropertyName} no puede ser mayor a {MaxLength}");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("{PropertyName} no puede ser no puede estar vacio")
                .MaximumLength(120).WithMessage("{PropertyName} no puede ser mayor a {MaxLength}");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("{PropertyName} no puede ser no puede estar vacio")
                .MaximumLength(80).WithMessage("{PropertyName} no puede ser mayor a {MaxLength}");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("{PropertyName} no puede ser no puede estar vacio")
                .MaximumLength(100).WithMessage("{PropertyName} no puede ser mayor a {MaxLength}");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("{PropertyName} no puede ser no puede estar vacio")
                .MaximumLength(100).WithMessage("{PropertyName} no puede ser mayor a {MaxLength}")
                .Equal(p => p.Password).WithMessage("{PropertyName} debe ser igual al Password");
        }
    }
}
