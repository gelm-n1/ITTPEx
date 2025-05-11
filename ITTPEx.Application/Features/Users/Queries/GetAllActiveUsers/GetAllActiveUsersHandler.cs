

using ITTPEx.Application.Interfaces.Repositories.Authentication;
using MediatR;

namespace ITTPEx.Application.Features.Users.Queries.GetAllActiveUsers
{
    public class GetAllActiveUsersHandler : IRequestHandler<GetAllActiveUsersQuery, List<GetAllActiveUsersDto>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllActiveUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<GetAllActiveUsersDto>> Handle(GetAllActiveUsersQuery query, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetActiveUsersAsync(cancellationToken);

            var userDtos = users.Select(u => new GetAllActiveUsersDto
            {
               Id = u.Id,
               Login = u.Login,
               Name = u.Name,
               Gender = u.Gender,
               Birthday = u.Birthday,
               RoleName = u.Role.Name
            }).ToList();

            return userDtos;

        }
    }
}
