
using System.Security.Claims;
using ITTPEx.Application.Exceptions;
using ITTPEx.Application.Interfaces.Repositories.Authentication;
using ITTPEx.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ITTPEx.Application.Features.Users.Commands.AdminUpdateUserLogin
{
    public class AdminUpdateUserLoginHandler : IRequestHandler<AdminUpdateUserLoginCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AdminUpdateUserLoginHandler(IUserRepository userRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Unit> Handle(AdminUpdateUserLoginCommand command, CancellationToken cancellationToken)
        {
            var normalizedLogin = command.NewLogin.ToLowerInvariant();

            if (await _userRepository.ExistByLoginAsync(normalizedLogin, cancellationToken))
                throw new UserAlreadyExistsException(normalizedLogin);

            var currentUserId =
                Guid.Parse(_httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier).Value);

            var currentUserLogin = await _userRepository.GetLoginByUserId(currentUserId, cancellationToken)
                ?? throw new NotFoundException(nameof(User), currentUserId);

            var user = await _userRepository.GetByIdAsync(command.UserId, cancellationToken)
                ?? throw new NotFoundException(nameof(User), command.UserId);

            if (user.RevokedOn != null) throw new ForbiddenEditException();

            user.Login = normalizedLogin;
            user.ModifiedBy = currentUserLogin;
            user.ModifiedOn = DateTime.UtcNow;

            await _userRepository.UpdateAsync(user, cancellationToken);

            return Unit.Value;
        }
    }
}
