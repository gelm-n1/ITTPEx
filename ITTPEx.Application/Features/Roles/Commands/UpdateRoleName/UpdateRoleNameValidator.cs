
using FluentValidation;

namespace ITTPEx.Application.Features.Roles.Commands.UpdateRoleName
{
    public class UpdateRoleNameValidator : AbstractValidator<UpdateRoleNameCommand>
    {
        public UpdateRoleNameValidator()
        {
            RuleFor(x => x.NewName)
                .NotEmpty().WithMessage("Наименование роли обязательно")
                .Matches(@"^[a-zA-Zа-яА-ЯёЁ\s]+$")
                .WithMessage("Наименование должно содержать только латинские буквы и цифры");
        }
    }
}
