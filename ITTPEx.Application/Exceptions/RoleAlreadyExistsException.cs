
namespace ITTPEx.Application.Exceptions
{
    public class RoleAlreadyExistsException : Exception
    {
        public RoleAlreadyExistsException(string name)
            : base($"Роль с наименованием '{name}' уже существует") { }
    }
}
