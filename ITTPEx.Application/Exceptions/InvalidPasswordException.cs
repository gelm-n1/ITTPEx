
namespace ITTPEx.Application.Exceptions
{
    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException() : base("Неверный пароль")
        {
            
        }
    }
}
