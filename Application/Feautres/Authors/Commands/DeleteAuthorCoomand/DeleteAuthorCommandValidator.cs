using FluentValidation;

namespace Application.Feautres.Authors.Commands.DeleteAuthorCoomand
{
    public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorCommandValidator()
        {
            RuleFor(x => x.AuthorId)
                .NotEmpty().WithMessage("{PropertyName no puede estar vacio}");
        }
    }
}
