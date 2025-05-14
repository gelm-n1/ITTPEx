
using System.Security.Claims;
using ITTPEx.Application.Exceptions;
using ITTPEx.Application.Interfaces.Repositories.Authentication;
using ITTPEx.Application.Interfaces.Services.Authentication;
using ITTPEx.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ITTPEx.Application.Features.Users.Commands.SelfUpdateUserPassword
{
    public class SelfUpdateUserPasswordHandler : IRequestHandler<SelfUpdateUserPasswordCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPasswordHasherService _passwordHasherService;

        public SelfUpdateUserPasswordHandler(IUserRepository userRepository,
            IHttpContextAccessor httpContextAccessor,
            IPasswordHasherService passwordHasherService)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
            _passwordHasherService = passwordHasherService;
        }

        public async Task<Unit> Handle(SelfUpdateUserPasswordCommand command, CancellationToken cancellationToken)
        {
            var currentUserId = 
                Guid.Parse(_httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier).Value);

            var user = await _userRepository.GetByIdAsync(currentUserId, cancellationToken)
                ?? throw new NotFoundException(nameof(User), currentUserId);

            if (user.RevokedOn != null) throw new ForbiddenEditException();

            if (!_passwordHasherService.VerifyPassword(command.OldPassword, user.HashPassword))
                throw new InvalidPasswordException();

            var newHashPassword = _passwordHasherService.GeneratePassword(command.NewPassword);

            user.HashPassword = newHashPassword;
            user.ModifiedBy = user.Login;
            user.ModifiedOn = DateTime.UtcNow;

            await _userRepository.UpdateAsync(user, cancellationToken);

            return Unit.Value;
        }
    }
}
