
using FluentValidation;

namespace ITTPEx.Application.Features.Users.Queries.GetUserByLogin
{
    public class GetUserByLoginValidator : AbstractValidator<GetUserByLoginQuery>
    {
        public GetUserByLoginValidator()
        {
            RuleFor(x => x.Login)
                .NotEmpty().WithMessage("Логин обязателен")
                .Matches(@"^[a-zA-Z0-9]+$")
                .WithMessage("Запрещены все символы кроме латинских букв и цифр");
        }
    }
}
