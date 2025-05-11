
using MediatR;

namespace ITTPEx.Application.Features.Users.Queries.GetUserByLogin
{
    public record GetUserByLoginQuery(string Login) : IRequest<GetUserByLoginDto>;
}