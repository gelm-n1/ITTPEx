
using System.Security.Claims;
using ITTPEx.Application.Exceptions;
using ITTPEx.Application.Interfaces.Repositories.Authentication;
using ITTPEx.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ITTPEx.Application.Features.Users.Commands.SelfUpdateUserProfile
{
    public class SelfUpdateUserProfileHandler : IRequestHandler<SelfUpdateUserProfileCommand, SelfUpdateUserProfileDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SelfUpdateUserProfileHandler(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<SelfUpdateUserProfileDto> Handle(SelfUpdateUserProfileCommand command, CancellationToken cancellationToken)
        {
            var currentUserId = 
                Guid.Parse(_httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier).Value);

            var user = await _userRepository.GetByIdAsync(currentUserId, cancellationToken)
                ?? throw new NotFoundException(nameof(User), currentUserId);

            if (user.RevokedOn != null) throw new ForbiddenEditException();

            user.Name = command.Name ?? user.Name;
            user.Gender = command.Gender ?? user.Gender;
            user.Birthday = command.Birthday ?? user.Birthday;
            user.ModifiedBy = user.Login;
            user.ModifiedOn = DateTime.UtcNow;

            await _userRepository.UpdateAsync(user, cancellationToken);

            var selfUpdateUserProfileDto = new SelfUpdateUserProfileDto
            {
                Name = user.Name,
                Gender = user.Gender,
                Birthday = user.Birthday
            };

            return selfUpdateUserProfileDto;
        }
    }
}
