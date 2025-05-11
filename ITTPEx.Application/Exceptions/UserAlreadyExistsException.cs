
namespace ITTPEx.Application.Exceptions
{
    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException(string login)
            : base($"Пользователь с логином '{login}' уже существует") { }
    }
}
