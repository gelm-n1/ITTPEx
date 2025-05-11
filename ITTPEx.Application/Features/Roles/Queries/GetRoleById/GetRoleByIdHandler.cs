
using ITTPEx.Application.Exceptions;
using ITTPEx.Application.Interfaces.Repositories.Authentication;
using ITTPEx.Domain.Entities;
using MediatR;

namespace ITTPEx.Application.Features.Roles.Queries.GetRoleById
{
    public class GetRoleByIdHandler : IRequestHandler<GetRoleByIdQuery, GetRoleByIdDto>
    {
        private readonly IRoleRepository _roleRepository;

        public GetRoleByIdHandler(IRoleRepository roleRepository) => _roleRepository = roleRepository;

        public async Task<GetRoleByIdDto> Handle(GetRoleByIdQuery query, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.GetByIdAsync(query.Id, cancellationToken) ?? 
                throw new NotFoundException(nameof(Role), query.Id);

            var roleDto = new GetRoleByIdDto
            {
                Id = role.Id,
                Name = role.Name
            };

            return roleDto;
        }
    }
}
