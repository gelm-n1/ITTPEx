
using FluentValidation;

namespace ITTPEx.Application.Features.Users.Commands.SelfUpdateUserPassword
{
    public class SelfUpdateUserPasswordValidator : AbstractValidator<SelfUpdateUserPasswordCommand>
    {
        public SelfUpdateUserPasswordValidator()
        {
            RuleFor(x => x.OldPassword)
                .NotEmpty().WithMessage("Старый пароль обязателен")
                .Length(8, 100).WithMessage("Длина пароля должна быть от 8 символов")
                .Matches(@"^[a-zA-Z0-9]+$")
                .WithMessage("Запрещены все символы кроме латинских букв и цифр");

            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("Новый пароль обязателен")
                .Length(8, 100).WithMessage("Длина пароля должна быть от 8 символов")
                .Matches(@"^[a-zA-Z0-9]+$")
                .WithMessage("Запрещены все символы кроме латинских букв и цифр");
        }
    }
}
