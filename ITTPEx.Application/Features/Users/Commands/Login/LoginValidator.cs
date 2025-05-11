
using FluentValidation;

namespace ITTPEx.Application.Features.Users.Commands.Login
{
    public class LoginValidator : AbstractValidator<LoginCommand>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Login)
                .NotEmpty().WithMessage("Логин обязателен")
                .Matches(@"^[a-zA-Z0-9]+$")
                .WithMessage("Запрещены все символы кроме латинских букв и цифр");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Пароль обязателен")
                .Length(8, 100).WithMessage("Длина пароля должна быть от 8 символов")
                .Matches(@"^[a-zA-Z0-9]+$")
                .WithMessage("Запрещены все символы кроме латинских букв и цифр");
        }
    }
}
