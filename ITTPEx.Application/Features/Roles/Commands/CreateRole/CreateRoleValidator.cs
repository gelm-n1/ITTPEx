
using FluentValidation;

namespace ITTPEx.Application.Features.Roles.Commands.CreateRole
{
    public class CreateRoleValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Наименование роли обязательно")
                .Matches(@"^[a-zA-Z0-9]+$")
                .WithMessage("Наименование должно содержать только латинские буквы и цифры");
        }
    }
}
