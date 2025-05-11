
using System.Security.Claims;
using ITTPEx.Application.Exceptions;
using ITTPEx.Application.Interfaces.Repositories.Authentication;
using ITTPEx.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ITTPEx.Application.Features.Users.Commands.AdminUpdateUserProfile
{
    public class AdminUpdateUserProfileHandler : IRequestHandler<AdminUpdateUserProfileCommand, AdminUpdateUserProfileDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AdminUpdateUserProfileHandler(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<AdminUpdateUserProfileDto> Handle(AdminUpdateUserProfileCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(command.Id, cancellationToken) 
                ?? throw new NotFoundException(nameof(User), command.Id);

            if (user.RevokedOn != null) throw new ForbiddenEditException();

            var currentUserId =
                Guid.Parse(_httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier).Value);

            var currentUserLogin = await _userRepository.GetLoginByUserId(currentUserId, cancellationToken)
                ?? throw new NotFoundException(nameof(User), currentUserId);

            user.Name = command.Name ?? user.Name;
            user.Gender = command.Gender ?? user.Gender;
            user.Birthday = command.Birthday ?? user.Birthday;
            user.ModifiedBy = currentUserLogin;
            user.ModifiedOn = DateTime.UtcNow;

            await _userRepository.UpdateAsync(user, cancellationToken);

            var adminUpdateUserProfileDto = new AdminUpdateUserProfileDto
            {
                Id = user.Id,
                Name = user.Name,
                Gender = user.Gender,
                Birthday = user.Birthday   
            };

            return adminUpdateUserProfileDto;

        }
    }
}
