
using ITTPEx.Application.Interfaces.Repositories.Authentication;
using MediatR;

namespace ITTPEx.Application.Features.Roles.Queries.GetAllRoles
{
    public class GetAllRolesHandler : IRequestHandler<GetAllRolesQuery, List<GetAllRolesDto>>
    {
        private readonly IRoleRepository _roleRepository;

        public GetAllRolesHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<List<GetAllRolesDto>> Handle(GetAllRolesQuery query, CancellationToken cancellationToken)
        {
            var roles = await _roleRepository.GetAllAsync(cancellationToken);

            var rolesDto = roles.Select(r => new GetAllRolesDto
            {
                Id = r.Id,
                Name = r.Name
            }).ToList();

            return rolesDto;
        }
    }
}
