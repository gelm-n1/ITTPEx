
using FluentValidation;

namespace ITTPEx.Application.Features.Users.Commands.SelfUpdateUserProfile
{
    public class SelfUpdateUserProfileValidator : AbstractValidator<SelfUpdateUserProfileCommand>
    {
        public SelfUpdateUserProfileValidator()
        {
            RuleFor(x => x.Name)
                .Matches(@"^[a-zA-Zа-яА-ЯёЁ\s]+$")
                .WithMessage("Имя должно содержать только русские/латинские буквы и пробелы");
        }
    }
}
