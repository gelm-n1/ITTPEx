
using ITTPEx.Application.Exceptions;
using System.Security.Claims;
using ITTPEx.Application.Interfaces.Repositories.Authentication;
using ITTPEx.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ITTPEx.Application.Features.Users.Commands.SelfUpdateUserLogin
{
    public class SelfUpdateUserLoginHandler : IRequestHandler<SelfUpdateUserLoginCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SelfUpdateUserLoginHandler(IUserRepository userRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Unit> Handle(SelfUpdateUserLoginCommand command, CancellationToken cancellationToken)
        {
            var normalizedLogin = command.Login.ToLowerInvariant();

            if (await _userRepository.ExistByLoginAsync(normalizedLogin, cancellationToken))
                throw new UserAlreadyExistsException(normalizedLogin);

            var currentUserId = 
                Guid.Parse(_httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier).Value);

            var user = await _userRepository.GetByIdAsync(currentUserId, cancellationToken)
                ?? throw new NotFoundException(nameof(User), currentUserId);

            if (user.RevokedOn != null) throw new ForbiddenEditException();

            user.Login = normalizedLogin;
            user.ModifiedBy = user.Login;
            user.ModifiedOn = DateTime.UtcNow;

            await _userRepository.UpdateAsync(user, cancellationToken);

            return Unit.Value;
        }

    }
}
