
using FluentValidation;

namespace ITTPEx.Application.Features.Users.Commands.AdminUpdateUserLogin
{
    public class AdminUpdateUserLoginValidator : AbstractValidator<AdminUpdateUserLoginCommand>
    {
        public AdminUpdateUserLoginValidator()
        {
            RuleFor(x => x.NewLogin)
               .NotEmpty().WithMessage("Логин обязателен")
               .Matches(@"^[a-zA-Z0-9]+$")
               .WithMessage("Логин должен содержать только латинские буквы и цифры");
        }
    }
}
