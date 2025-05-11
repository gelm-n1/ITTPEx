

using FluentValidation;

namespace ITTPEx.Application.Features.Users.Commands.AdminUpdateUserProfile
{
    public class AdminUpdateUserProfileValidator : AbstractValidator<AdminUpdateUserProfileCommand>
    {
        public AdminUpdateUserProfileValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Имя обязательно")
                .Matches(@"^[a-zA-Zа-яА-ЯёЁ\s]+$")
                .WithMessage("Имя должно содержать только русские/латинские буквы и пробелы");
        }
    }
}
