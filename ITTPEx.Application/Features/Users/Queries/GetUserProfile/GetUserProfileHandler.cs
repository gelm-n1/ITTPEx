
using System.Security.Claims;
using ITTPEx.Application.Exceptions;
using ITTPEx.Application.Interfaces.Repositories.Authentication;
using ITTPEx.Application.Interfaces.Services.Authentication;
using ITTPEx.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ITTPEx.Application.Features.Users.Queries.GetUserProfile
{
    public class GetUserProfileHandler : IRequestHandler<GetUserProfileQuery, GetUserProfileDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasherService _passwordHasherService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetUserProfileHandler(IUserRepository userRepository,
            IPasswordHasherService passwordHasherService,
            IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _passwordHasherService = passwordHasherService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<GetUserProfileDto> Handle(GetUserProfileQuery query, CancellationToken cancellationToken)
        {
            var currentUserId =
                Guid.Parse(_httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier).Value);

            var currentUserLogin = await _userRepository.GetLoginByUserId(currentUserId, cancellationToken)
                ?? throw new NotFoundException(nameof(User), currentUserId);

            var user = await _userRepository.GetByLoginAsync(currentUserLogin, cancellationToken)
                ?? throw new NotFoundException(nameof(User), currentUserLogin);

            if (user.RevokedOn != null) throw new ForbiddenEditException();

            if (!_passwordHasherService.VerifyPassword(query.Password, user.HashPassword))
                    throw new InvalidCredentialsException();

            var userDto = new GetUserProfileDto
            {
                 Name = user.Name,
                 Gender = user.Gender,
                 Birthday = user.Birthday
            };

            return userDto;
        }
    }
}
