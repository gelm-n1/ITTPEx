
using ITTPEx.Application.Exceptions;
using ITTPEx.Application.Interfaces.Repositories.Authentication;
using ITTPEx.Domain.Entities;
using MediatR;

namespace ITTPEx.Application.Features.Roles.Commands.CreateRole
{
    public class CreateRoleHandler : IRequestHandler<CreateRoleCommand, CreateRoleDto>
    {
        private readonly IRoleRepository _roleRepository;

        public CreateRoleHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<CreateRoleDto> Handle(CreateRoleCommand command, CancellationToken cancellationToken)
        {
            var normalizedName = command.Name.ToLowerInvariant();

            if (await _roleRepository.ExistByNameAsync(normalizedName, cancellationToken))
                throw new RoleAlreadyExistsException(normalizedName);

            var guid = Guid.NewGuid();

            var role = new Role(guid, normalizedName);

            await _roleRepository.AddAsync(role, cancellationToken);

            var createRoleDto = new CreateRoleDto
            {
                Id = role.Id,
                Name = role.Name
            };

            return createRoleDto;
        }
    }
}
