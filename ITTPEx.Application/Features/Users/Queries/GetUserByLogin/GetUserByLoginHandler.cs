
using ITTPEx.Application.Exceptions;
using ITTPEx.Application.Interfaces.Repositories.Authentication;
using ITTPEx.Domain.Entities;
using MediatR;

namespace ITTPEx.Application.Features.Users.Queries.GetUserByLogin
{
    public class GetUserByLoginHandler : IRequestHandler<GetUserByLoginQuery, GetUserByLoginDto>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByLoginHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetUserByLoginDto> Handle(GetUserByLoginQuery query, CancellationToken cancellationToken)
        {
            var normalizedLogin = query.Login.ToLowerInvariant();

            var user = await _userRepository.GetByLoginAsync(normalizedLogin, cancellationToken)
                ?? throw new NotFoundException(nameof(User), normalizedLogin);

            var userDto = new GetUserByLoginDto
            {
                Name = user.Name,
                Gender = user.Gender,
                Birthday = user.Birthday,
                IsActive = user.RevokedOn == null
            };

            return userDto;
        }
    }
}
