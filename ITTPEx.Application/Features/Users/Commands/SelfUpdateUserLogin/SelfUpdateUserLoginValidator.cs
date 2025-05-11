

using FluentValidation;

namespace ITTPEx.Application.Features.Users.Commands.SelfUpdateUserLogin
{
    public class SelfUpdateUserLoginValidator : AbstractValidator<SelfUpdateUserLoginCommand>
    {
        public SelfUpdateUserLoginValidator()
        {
            RuleFor(x => x.Login)
                .NotEmpty().WithMessage("Логин обязателен")
                .Matches(@"^[a-zA-Z0-9]+$")
                .WithMessage("Логин должен содержать только латинские буквы и цифры");
        }
    }
}
