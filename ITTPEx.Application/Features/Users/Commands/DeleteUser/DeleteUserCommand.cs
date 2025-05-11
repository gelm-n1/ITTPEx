﻿
using MediatR;

namespace ITTPEx.Application.Features.Users.Commands.DeleteUser
{
    public record DeleteUserCommand(Guid Id) : IRequest<Unit>;
}
