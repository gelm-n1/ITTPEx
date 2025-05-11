
using FluentValidation;

namespace ITTPEx.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Login)
                .NotEmpty().WithMessage("Логин обязателен")
                .Matches(@"^[a-zA-Z0-9]+$")
                .WithMessage("Логин должен содержать только латинские буквы и цифры");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Пароль обязателен")
                .Length(8, 100).WithMessage("Длина пароля должна быть от 8 символов")
                .Matches(@"^[a-zA-Z0-9]+$")
                .WithMessage("Пароль должен содержать только латинские буквы и цифры");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Имя обязательно")
                .Matches(@"^[a-zA-Zа-яА-ЯёЁ\s]+$")
                .WithMessage("Имя должно содержать только русские/латинские буквы и пробелы");
        }
    }
}
