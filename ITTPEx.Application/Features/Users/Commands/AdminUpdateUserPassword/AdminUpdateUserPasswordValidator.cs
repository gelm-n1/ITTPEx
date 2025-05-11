
using FluentValidation;

namespace ITTPEx.Application.Features.Users.Commands.AdminUpdateUserPassword
{
    public class AdminUpdateUserPasswordValidator : AbstractValidator<AdminUpdateUserPasswordCommand>
    {
        public AdminUpdateUserPasswordValidator()
        {
            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("Пароль обязателен")
                .Length(8, 100).WithMessage("Длина пароля должна быть от 8 символов")
                .Matches(@"^[a-zA-Z0-9]+$")
                .WithMessage("Запрещены все символы кроме латинских букв и цифр");
        }
    }
}
