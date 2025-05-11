
using ITTPEx.Application.Exceptions;
using ITTPEx.Application.Interfaces.Repositories.Authentication;
using ITTPEx.Application.Interfaces.Services.Authentication;
using ITTPEx.Domain.Consts;
using ITTPEx.Domain.Entities;
using MediatR;

namespace ITTPEx.Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, RegisterUserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasherService _passwrodHasherService;
        private readonly IRoleRepository _roleRepository;

        public RegisterUserHandler(IUserRepository userRepository, 
            IPasswordHasherService passwordHasherService, 
            IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _passwrodHasherService = passwordHasherService;
            _roleRepository = roleRepository;
        }

        public async Task<RegisterUserDto> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            var normalizedLogin = command.Login.ToLowerInvariant();

            if (await _userRepository.ExistByLoginAsync(normalizedLogin, cancellationToken))
                throw new UserAlreadyExistsException(normalizedLogin);

            var guid = Guid.NewGuid();

            var role = await _roleRepository.GetByNameAsync(DefaultRoles.User, cancellationToken) ??
                throw new NotFoundException(nameof(Role), DefaultRoles.User);

            var hashPassword = _passwrodHasherService.GeneratePassword(command.Password);

            var user = new User(id: guid,
                login: normalizedLogin,
                hashPassword: hashPassword,
                name: command.Name,
                gender: command.Gender,
                birthday: command.Birthday,
                roleId: role.Id,
                createdBy: normalizedLogin);

            await _userRepository.AddAsync(user, cancellationToken);

            var userDto = new RegisterUserDto
            {
                Id = user.Id,
                Login = user.Login
            };

            return userDto;
        }
    }
}
