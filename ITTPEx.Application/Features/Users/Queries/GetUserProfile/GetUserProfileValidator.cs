
using FluentValidation;

namespace ITTPEx.Application.Features.Users.Queries.GetUserProfile
{
    public class GetUserProfileValidator : AbstractValidator<GetUserProfileQuery>
    {
        public GetUserProfileValidator()
        {
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Пароль обязателен")
                .Length(8, 100).WithMessage("Длина пароля должна быть от 8 символов")
                .Matches(@"^[a-zA-Z0-9]+$")
                .WithMessage("Запрещены все символы кроме латинских букв и цифр");
        }
    }
}
