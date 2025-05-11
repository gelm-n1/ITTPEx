
using System.Security.Claims;
using ITTPEx.Application.Exceptions;
using ITTPEx.Application.Interfaces.Repositories.Authentication;
using ITTPEx.Application.Interfaces.Services.Authentication;
using ITTPEx.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ITTPEx.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasherService _passwordHasherService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRoleRepository _roleRepository;

        public CreateUserHandler(IUserRepository userRepository,
            IPasswordHasherService passwordHasherService,
            IHttpContextAccessor httpContextAccessor,
            IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _passwordHasherService = passwordHasherService;
            _roleRepository = roleRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<CreateUserDto> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var currentUserId =
                Guid.Parse(_httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier).Value);

            var currentUserLogin = await _userRepository.GetLoginByUserId(currentUserId, cancellationToken)
                ?? throw new NotFoundException(nameof(User), currentUserId);

            var normalizedLogin = command.Login.ToLowerInvariant();

            if (await _userRepository.ExistByLoginAsync(normalizedLogin, cancellationToken))
                throw new UserAlreadyExistsException(normalizedLogin);

            var guid = Guid.NewGuid();
            var role = await _roleRepository.GetByNameAsync(command.RoleName, cancellationToken) ??
                throw new NotFoundException(nameof(Role), command.RoleName);

            var hashPassword = _passwordHasherService.GeneratePassword(command.Password);

            var user = new User(id: guid,
                login: normalizedLogin, 
                hashPassword: hashPassword, 
                name: command.Name,
                gender: command.Gender, 
                birthday: command.Birthday, 
                roleId: role.Id, 
                createdBy: currentUserLogin);

            await _userRepository.AddAsync(user, cancellationToken);

            var userDto = new CreateUserDto
            {
                Id = user.Id,
                Login = normalizedLogin
            };

            return userDto;

        }
    }
}
