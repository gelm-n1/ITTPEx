
using System.Security.Claims;
using ITTPEx.Application.Exceptions;
using ITTPEx.Application.Interfaces.Repositories.Authentication;
using ITTPEx.Application.Interfaces.Services.Authentication;
using ITTPEx.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ITTPEx.Application.Features.Users.Commands.AdminUpdateUserPassword
{
    public class AdminUpdateUserPasswordHandler : IRequestHandler<AdminUpdateUserPasswordCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPasswordHasherService _passwordHasherService;

        public AdminUpdateUserPasswordHandler(IUserRepository userRepository,
            IHttpContextAccessor httpContextAccessor,
            IPasswordHasherService passwordHasherService)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
            _passwordHasherService = passwordHasherService;
        }

        public async Task<Unit> Handle(AdminUpdateUserPasswordCommand command, CancellationToken cancellationToken)
        {
            var currentUserId =
                Guid.Parse(_httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier).Value);

            var currentUserLogin = await _userRepository.GetLoginByUserId(currentUserId, cancellationToken)
                ?? throw new NotFoundException(nameof(User), currentUserId);

            var user = await _userRepository.GetByIdAsync(command.UserId, cancellationToken) 
                ?? throw new NotFoundException(nameof(User), command.UserId);

            if (user.RevokedOn != null) throw new ForbiddenEditException();

            var newHashPassword = _passwordHasherService.GeneratePassword(command.NewPassword);

            user.HashPassword = newHashPassword;
            user.ModifiedBy = currentUserLogin;
            user.ModifiedOn = DateTime.UtcNow;

            await _userRepository.UpdateAsync(user, cancellationToken);

            return Unit.Value;
        }
    }
}
