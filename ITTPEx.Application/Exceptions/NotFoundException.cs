
namespace ITTPEx.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string entity, object key)
            : base($"Сущность {entity} с параметром {key} не найдена")
        {
        }
    }
}
