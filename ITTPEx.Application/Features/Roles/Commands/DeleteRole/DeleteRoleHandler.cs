
using ITTPEx.Application.Exceptions;
using ITTPEx.Application.Interfaces.Repositories.Authentication;
using ITTPEx.Domain.Entities;
using MediatR;

namespace ITTPEx.Application.Features.Roles.Commands.DeleteRole
{
    public class DeleteRoleHandler : IRequestHandler<DeleteRoleCommand, Unit>
    {

        private readonly IRoleRepository _roleRepository;

        public DeleteRoleHandler(IRoleRepository roleRepsitory)
        {
            _roleRepository = roleRepsitory;
        }

        public async Task<Unit> Handle(DeleteRoleCommand query, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.GetByIdAsync(query.Id, cancellationToken) ??
                throw new NotFoundException(nameof(Role), query.Id);

            await _roleRepository.DeleteAsync(role, cancellationToken);

            return Unit.Value;
        }
    }
}
