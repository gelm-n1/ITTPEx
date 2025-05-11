
using ITTPEx.Application.Interfaces.Repositories.Authentication;
using MediatR;

namespace ITTPEx.Application.Features.Users.Queries.GetUsersOlderThan
{
    public class GetUsersOlderThanHandler : IRequestHandler<GetUsersOlderThanQuery, List<GetUsersOlderThanDto>>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersOlderThanHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<GetUsersOlderThanDto>> Handle(GetUsersOlderThanQuery query, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetUsersOlderThan(query.minAge, cancellationToken);

            var userDtos = users.Select(u => new GetUsersOlderThanDto
            {
                Id = u.Id,
                Login = u.Login,
                Name = u.Name,
                Gender = u.Gender,
                Birthday = u.Birthday,
                IsActive = u.RevokedOn == null,
                RoleName = u.Role.Name
            }).ToList();

            return userDtos;
        }
    }
}
