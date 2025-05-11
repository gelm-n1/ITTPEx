
using ITTPEx.Application.Exceptions;
using ITTPEx.Application.Interfaces.Repositories.Authentication;
using ITTPEx.Domain.Entities;
using MediatR;

namespace ITTPEx.Application.Features.Roles.Commands.UpdateRoleName
{
    public class UpdateRoleNameHandler : IRequestHandler<UpdateRoleNameCommand, Unit>
    {
        private readonly IRoleRepository _roleRepository;

        public UpdateRoleNameHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<Unit> Handle(UpdateRoleNameCommand command, CancellationToken cancellationToken)
        {
            var normalizedName = command.NewName.ToLowerInvariant();

            var role = await _roleRepository.GetByIdAsync(command.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Role), command.Id);

            role.Name = normalizedName;

            await _roleRepository.UpdateAsync(role, cancellationToken);

            return Unit.Value;
        }
    }
}
