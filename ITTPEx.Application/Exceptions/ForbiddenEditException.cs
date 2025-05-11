

namespace ITTPEx.Application.Exceptions
{
    public class ForbiddenEditException : Exception
    {
        public ForbiddenEditException() : base("Действие запрещено, ваш аккаунт заблокирован") {}
    }
}
