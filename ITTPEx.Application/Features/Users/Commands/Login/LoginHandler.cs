
using ITTPEx.Application.Exceptions;
using ITTPEx.Application.Interfaces.Repositories.Authentication;
using ITTPEx.Application.Interfaces.Services.Authentication;
using ITTPEx.Application.Interfaces.Services.Authentication.Tokens;
using ITTPEx.Domain.Entities;
using MediatR;

namespace ITTPEx.Application.Features.Users.Commands.Login
{
    public class LoginHandler : IRequestHandler<LoginCommand, LoginDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IPasswordHasherService _passwordHasherService;
        private readonly IRoleRepository _roleRepository;

        public LoginHandler(IUserRepository userRepository,
            IJwtTokenService jwtTokenService,
            IPasswordHasherService passwordHasherService,
            IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _jwtTokenService = jwtTokenService;
            _passwordHasherService = passwordHasherService;
            _roleRepository = roleRepository;
        }

        public async Task<LoginDto> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            var normalizedLogin = command.Login.ToLowerInvariant();

            var user = await _userRepository.GetByLoginAsync(normalizedLogin, cancellationToken) 
                ?? throw new InvalidCredentialsException();

            var passwordCheck = _passwordHasherService.VerifyPassword(command.Password, user.HashPassword);
            if (!passwordCheck) throw new InvalidCredentialsException();

            var role = await _roleRepository.GetByIdAsync(user.RoleId, cancellationToken) 
                ?? throw new NotFoundException(nameof(Role), user.RoleId);

            var encodedJwt = _jwtTokenService.GenerateJwtToken(user.Id.ToString(), role.Name);

            var loginDto = new LoginDto
            {
                UserId = user.Id,
                Role = role.Name,
                Token = encodedJwt
            };

            return loginDto;
        }
    }
}
